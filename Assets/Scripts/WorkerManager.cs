using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    [SerializeField]
    public GameObject workerRef;
    [SerializeField]
    public List<GameObject> m_workerList;

	// Use this for initialization
	void Awake ()
    {
        m_workerList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
