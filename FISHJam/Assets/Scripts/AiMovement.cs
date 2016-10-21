using UnityEngine;
using System.Collections;

public class AiMovement : MonoBehaviour {

    enum tempDesireEnum
    {
        caffeteria,
        managerOffice,
        mainRoom,
        toilet,
        printer
    }

    enum aiState
    {
        needsDesire,
        needsToMove,
        goingToDesire,
        arrivedAtDesire
    }
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
    }

    //main state machine for the AI is done in the update
    void Update()
    {
        if(m_state == (int)aiState.needsDesire)
        {
            //simulateDesire();
            getDesire();
            m_state = (int)aiState.needsToMove;
        }
        else if(m_state == (int)aiState.needsToMove)
        {
            setGoal();
            //m_state = (int)aiState.goingToDesire;
            moveTowardsGoal();
        }
        else if (m_state == (int)aiState.goingToDesire)
        {
            //check to see if arrived yet
        }
        else if (m_state == (int)aiState.arrivedAtDesire)
        {
            //has arrived so change the worker's desires slightly over time
            //once full, set state to needs desire
        }
        
    }

    void OnTriggerEnter(Collider _collider)
    {
        if(_collider == m_goal.GetComponent<Collider>())
        {
            m_state = (int)aiState.arrivedAtDesire;
        }
        else
        {

        }
    }

    //this functions sets the goal to whatever you want it to be by raycasting out to find a collider
    public void setGoal()
    {
        RaycastHit[] colliders = Physics.SphereCastAll(gameObject.transform.position, 10.0f, Vector3.zero);
        
        
        for (int iter = 0; colliders.Length > iter; iter++)
        {
            if(m_desire == "thirsty" && colliders[iter].collider.tag == "WaterCooler")
            {
                _goal = colliders[iter].collider.gameObject;
            }
            else if(m_desire == "hungry" && colliders[iter].collider.tag == "CaffeteriaTable")
            {
                _goal = colliders[iter].collider.gameObject;
            }
            else if (m_desire == "print" && colliders[iter].collider.tag == "Printer")
            {
                _goal = colliders[iter].collider.gameObject;
            }
            else if (m_desire == "toilet" && colliders[iter].collider.tag == "toilet")
            {
                _goal = colliders[iter].collider.gameObject;
            }
            else
            {
                _goal = null;
            }
        }
        m_goal = _goal;
    }

    //this function starts the worker moving towards the goal
    void moveTowardsGoal()
    {
        m_agent.destination = m_goal.transform.Find("NPCPosition").transform.position;
        m_state = (int)aiState.goingToDesire;
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

    
}
