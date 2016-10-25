using UnityEngine;
using System.Collections;


public class AiMovement : MonoBehaviour {

   /* enum tempDesireEnum
    {
        caffeteria,
        managerOffice,
        mainRoom,
        toilet,
        printer
    }*/

    enum aiState
    {
        needsDesire,
        needsToMove,
        goingToDesire,
        arrivedAtDesire
    }

    public Animator m_animation;
    public AudioSource m_audio;
    public AudioClip m_worker1;
    public AudioClip m_worker2;
    public AudioClip m_workerAnnoyed;
    public AudioClip m_workerRiot;

    public WorkerTally m_workerTally;
    public GameObject m_goal;
    private GameObject _goal;
    public NavMeshAgent m_agent;
    public WorkerScript m_desires;
    public string m_desire;
    public int m_state;
    public int m_moveCounter;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_desires = gameObject.GetComponent<WorkerScript>();
        m_state = (int)aiState.needsDesire;
        m_animation = gameObject.GetComponent<Animator>();
        m_animation.Play("Neutral");
        m_audio = gameObject.GetComponent<AudioSource>();
        m_workerTally = gameObject.GetComponent<WorkerTally>();
    }

    //main state machine for the AI is done in the update
    void Update()
    {
        if(m_state == (int)aiState.needsDesire)
        {
            //simulateDesire();
            getDesire();
            if(m_desire == null)
            {

            }
            else
            {
                m_state = (int)aiState.needsToMove;
            }
            
        }
        else if(m_state == (int)aiState.needsToMove)
        {
            m_moveCounter = 0;
            setGoal();
            //m_state = (int)aiState.goingToDesire;
            moveTowardsGoal();
        }
        else if (m_state == (int)aiState.goingToDesire)
        {
            //check to see if arrived yet which is done in OnTriggerEnter
            //Debug.Log("boop");
            if(m_moveCounter == 2000)
            {
                moveTowardsGoal();
                m_moveCounter = 0;
            }
            m_moveCounter++;
        }
        else if (m_state == (int)aiState.arrivedAtDesire)
        {
            //System.Threading.Thread.Sleep(5000);
            StartCoroutine(wait());
            //yield return new WaitForSeconds(5.0f);
            //has arrived so change the worker's desires slightly over time
            //once full, set state to needs desire
           
        
        }
        
    }

    void OnTriggerStay(Collider _collider)
    {
        if((_collider.tag == "NPCPosition") && (m_state == (int)aiState.goingToDesire))
        {

            if (m_workerTally.m_totalFrustration > 50)
            {
                m_audio.clip = m_workerAnnoyed;
            }
            else
            {
                m_audio.clip = m_worker2;
            }
            if (m_workerTally.m_totalFrustration >= 90)
            {
                m_audio.clip = m_workerRiot;
            }
            else
            {
                m_audio.clip = m_worker2;
            }

            if (_collider.gameObject.transform.parent.GetComponent<InteractableBase>().m_type == InteractableManager.ObjectType.TOILET && m_desire == "toilet")
            {
                m_state = (int)aiState.arrivedAtDesire;
                m_animation.Play("Work");
                //Debug.Log("Boop");
            }
            else if (_collider.gameObject.transform.parent.GetComponent<InteractableBase>().m_type == InteractableManager.ObjectType.WATERCOOLER && m_desire == "thirsty")
            {
                m_state = (int)aiState.arrivedAtDesire;
                m_animation.Play("Work");
                //Debug.Log("Boop");
            }
            else if (_collider.gameObject.transform.parent.GetComponent<InteractableBase>().m_type == InteractableManager.ObjectType.PRINTER && m_desire == "print")
            {
                m_state = (int)aiState.arrivedAtDesire;
                m_animation.Play("Work");
                //Debug.Log("Boop");
            }
            else if (_collider.gameObject.transform.parent.GetComponent<InteractableBase>().m_type == InteractableManager.ObjectType.FRIDGE && m_desire == "hungry")
            {
                m_state = (int)aiState.arrivedAtDesire;
                m_animation.Play("Work");
                //Debug.Log("Boop");
            }
            else if (_collider.gameObject.transform.parent.GetComponent<InteractableBase>().m_type == InteractableManager.ObjectType.TABLE && m_desire == "desk")
            {

                m_state = (int)aiState.arrivedAtDesire;
                m_animation.Play("Work");
                m_audio.Play();
                //Debug.Log("Boop");
            }

            else
            {

            }
        }
        else
        {

        }
    }

    //this functions sets the goal to whatever you want it to be by raycasting out to find a collider
    public void setGoal()
    {
        //InteractableManager manager = FindObjectOfType<InteractableManager>();

        InteractableManager.ObjectType type;

        if (m_desire == "thirsty")
        {
            type = InteractableManager.ObjectType.WATERCOOLER;
            
        }
        else if (m_desire == "hungry")
        {
            type = InteractableManager.ObjectType.FRIDGE;

        }
        else if (m_desire == "print")
        {
            type = InteractableManager.ObjectType.PRINTER;

        }
        else if (m_desire == "toilet")
        {
            type = InteractableManager.ObjectType.TOILET;

        }
        else if(m_desire == "desk")
        {
            type = InteractableManager.ObjectType.TABLE;
        }
        else
        {
            type = InteractableManager.ObjectType.TABLE;
        }

        _goal = InteractableManager.m_instance.GetObjectOfType(type, true, true, gameObject.transform.position).gameObject; 

        /*for (int iter = 0; manager.m_objectReferences.Count > iter; iter++)
        {
            
            if(m_desire == "thirsty" && manager.GetObjectOfType() == InteractableManager.ObjectType.TOILET)
            {
                _goal = manager.m_objectReferences[iter].gameObject;
                break;
            }
            else if(m_desire == "hungry" && manager.m_objectReferences[iter].m_type == InteractableManager.ObjectType.TOILET)
            {
                _goal = manager.m_objectReferences[iter].gameObject;
                break;
            }
            else if (m_desire == "print" && manager.m_objectReferences[iter].m_type == InteractableManager.ObjectType.TOILET)
            {
                _goal = manager.m_objectReferences[iter].gameObject;
                break;
            }
            else if (m_desire == "toilet" && manager.m_objectReferences[iter].g == InteractableManager.ObjectType.TOILET)
            {
                _goal = manager.m_objectReferences[iter].gameObject;
                break;
            }
            else
            {
                _goal = null;
            }
        }*/
        m_goal = _goal;
    }

    //this function starts the worker moving towards the goal
    void moveTowardsGoal()
    {
        m_audio.clip = m_worker1;
        m_audio.Play();
        if(m_goal == null)
        {
            //Debug.Log("Boop");
            m_state = (int)aiState.needsToMove;
        }
        else
        {
            m_agent.destination = m_goal.GetComponent<ObjectReference>().m_position; 
            m_state = (int)aiState.goingToDesire;
            m_animation.Play("Walk");
        }
        
    }

    //this function simply checks to see if it can put the agent back onto the navmesh if it falls off
    void checkToSeeIfOffGrid()
    {
        if(m_agent.isOnNavMesh == false)
        {
            m_agent.transform.position = GameObject.FindGameObjectWithTag("WorkerSpawn").transform.position;

            if (m_agent.isOnNavMesh == false)
            {
                m_agent.transform.position = GameObject.FindGameObjectWithTag("WorkerSpawn").transform.position;

                if (m_agent.isOnNavMesh == false)
                {
                    Debug.Log("Error. Agent could not go to navmesh");
                }
               
            }
        }
        else
        {
            //do nothing
        }
    }

    void getDesire()
    {
        m_desire = m_desires.m_currentDesire;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5.0f);
        
        m_desire = m_desires.AssignDesireToWorker();

        m_state = (int)aiState.needsToMove;
    }
}
