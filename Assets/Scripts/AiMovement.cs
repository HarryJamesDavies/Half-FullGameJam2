using UnityEngine;
using System.Collections;

public class AiMovement : MonoBehaviour {

    public GameObject goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
    }

}
