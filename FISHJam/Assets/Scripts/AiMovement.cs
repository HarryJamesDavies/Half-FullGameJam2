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

    public Animator animation;

    public GameObject m_goal;
    private GameObject _goal;
    public NavMeshAgent m_agent;
    public WorkerScript m_desires;
    public string m_desire;
    public int m_state;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_desires = gameObject.GetComponent<WorkerScript>();
        m_state = (int)aiState.needsDesire;
        animation = gameObject.GetComponent<Animator>();
        animation.Play("Neutral");
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
            
            setGoal();
            //m_state = (int)aiState.goingToDesire;
            moveTowardsGoal();
        }
        else if (m_state == (int)aiState.goingToDesire)
        {
            //check to see if arrived yet which is done in OnTriggerEnter
        }
        else if (m_state == (int)aiState.arrivedAtDesire)
        {
            wait();
            //has arrived so change the worker's desires slightly over time
            //once full, set state to needs desire
            m_state = (int)aiState.needsDesire;
        }
        
    }

    void OnTriggerStay(Collider _collider)
    {
        if(_collider == m_goal.GetComponent<Collider>() && m_state == (int)aiState.goingToDesire)
        {
            m_state = (int)aiState.arrivedAtDesire;
            animation.Play("Work");
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
            type = InteractableManager.ObjectType.TABLE;
            
        }
        else if (m_desire == "hungry")
        {
            type = InteractableManager.ObjectType.TABLE;

        }
        else if (m_desire == "print")
        {
            type = InteractableManager.ObjectType.TABLE;

        }
        else if (m_desire == "toilet")
        {
            type = InteractableManager.ObjectType.TABLE;

        }
        else
        {
            type = InteractableManager.ObjectType.TABLE;
        }

        _goal = InteractableManager.m_instance.GetObjectOfType(type, true, true, gameObject.transform.position).gameObject; //BREAKS HERE

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
        if(m_goal == null)
        {
            m_state = (int)aiState.needsToMove;
        }
        else
        {
            m_agent.destination = m_goal.GetComponent<ObjectReference>().m_position;//.Find("NPCPosition").transform.position;
            m_state = (int)aiState.goingToDesire;
            animation.Play("Walk");
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
        //print(Time.time);
        yield return new WaitForSeconds(5);
        //print(Time.time);
    }
}
