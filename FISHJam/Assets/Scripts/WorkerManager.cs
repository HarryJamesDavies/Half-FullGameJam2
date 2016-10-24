using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    public static WorkerManager worker_instance = null;

    [SerializeField]
    public List<GameObject> m_WorkerList;
    public GameObject m_Worker;
    private int m_currentWorkerPop = 1;
    public Transform spawnPoint;

    public float m_globalFrustration = 0;
    public float m_globalSuspicion = 0;

    //global sliders
    public Slider m_globalFrustrationSlider;
    public Slider m_globalSuspicionSlider;

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

    void Update()
    {
        //foreach(GameObject _worker in m_WorkerList)
        //{
        //    m_globalFrustration += _worker.GetComponent<WorkerTally>().m_totalFrustration;
        //    m_globalSuspicion += _worker.GetComponent<WorkerTally>().m_totalSuspicion;
        //}

        //constantly update global sliders
        m_globalFrustrationSlider.value = m_globalFrustration;
        m_globalSuspicionSlider.value = m_globalSuspicion;
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
