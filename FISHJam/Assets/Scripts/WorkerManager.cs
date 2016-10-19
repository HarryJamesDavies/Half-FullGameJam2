using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    [SerializeField]
    public List<GameObject> m_workerList;
    public GameObject WorkerManagerprefab;
    private bool spawnWorker = false;

    public Transform spawnPoint;

    void Start()
    {
        PopulateWorkerList();
        SpawnAllWorkers();
                
    }

	// Use this for initialization
	void Awake ()
    {
        m_workerList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    private void PopulateWorkerList()
    {
        for (int i = 0; i < 10; i ++)
        {
            m_workerList.Add(WorkerManagerprefab);
        }
        spawnWorker = true;
    }

    private void SpawnAllWorkers()
    {
        for (int i = 0; i < m_workerList.Count; i++)
        {
            //spawn the enemy
            Instantiate(WorkerManagerprefab, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
