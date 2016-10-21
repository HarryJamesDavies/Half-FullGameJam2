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
    public NavMeshAgent m_agent;
    public WorkerScript m_desires;
    public int desire;
    public int state;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_desires = gameObject.GetComponent<WorkerScript>();
        state = (int)aiState.needsDesire;
    }

    void Update()
    {
        if(state == (int)aiState.needsDesire)
        {
            simulateDesire();
        }
        else if(state == (int)aiState.needsToMove)
        {
            setGoal(null);
            moveTowardsGoal();
        }
        else if (state == (int)aiState.goingToDesire)
        {
            //check to see if arrived yet
        }
        else if (state == (int)aiState.arrivedAtDesire)
        {
            //has arrived so change the worker's desires slightly over time
            //once full, set state to needs desire
        }
        
    }

    //this functions sets the goal to whatever you want it to be
    public void setGoal(GameObject _goal)
    {
        m_goal = _goal;
    }

    //this function starts the worker moving towards the goal
    void moveTowardsGoal()
    {
        m_agent.destination = m_goal.transform.position;
        state = (int)aiState.goingToDesire;
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

    void simulateDesire()
    {
        desire = Random.Range(0, 4);
        state = (int)aiState.needsToMove;
    }

    
}
