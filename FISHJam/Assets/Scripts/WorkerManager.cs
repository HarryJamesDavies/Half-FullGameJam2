using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    [SerializeField]
    public List<GameObject> m_WorkerList;
    public GameObject m_Worker;
    private int m_currentWorkerPop = 10;
    public Transform spawnPoint;

    void Start()
    {
        PopulateWorkerList();
        StartCoroutine(SpawnAllWorkers());              
    }

    // Use this for initialization
    void Awake()
    {
        m_WorkerList = new List<GameObject>();
    }

    private void PopulateWorkerList()
    {
        //fill the list with all enemies
        for (int i = 0; i < m_currentWorkerPop; i++)
        {
            m_WorkerList.Add(m_Worker);
        }
    }

    IEnumerator SpawnAllWorkers()
    {
        for (int i = 0; i < m_WorkerList.Count; i++)
        {
            //spawn the enemy
            Instantiate(m_Worker, spawnPoint.position, spawnPoint.rotation);
            //And wait 1 second to spawn another
            yield return new WaitForSeconds(1f);
        }
        
    }
}
