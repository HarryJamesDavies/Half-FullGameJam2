using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    public static WorkerManager worker_instance = null;

    [SerializeField]
    public List<GameObject> m_WorkerList;
    public GameObject m_Worker;
    private int m_currentWorkerPop = 10;
    public Transform spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnAllWorkers());
    }
    // Use this for initialization
    void Awake()
    {
        if (worker_instance == null)
        {
            worker_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_WorkerList = new List<GameObject>();
    }

    public void AddGameObject(GameObject worker)
    {
       
    }

    IEnumerator SpawnAllWorkers()
    {
        for (int i = 0; i < m_currentWorkerPop; i++)
        {
            //spawn the enemy and add it to the list
           GameObject temp = (GameObject) Instantiate(m_Worker, spawnPoint.position, spawnPoint.rotation);
           m_WorkerList.Add(temp);
            //And wait 1 second to spawn another
            yield return new WaitForSeconds(1f);
        }
        
    }
}
