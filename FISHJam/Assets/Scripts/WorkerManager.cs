﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WorkerManager : MonoBehaviour {

    public static WorkerManager worker_instance = null;

    [SerializeField]
    public List<GameObject> m_WorkerList;
    public GameObject m_Worker;
    public int m_currentWorkerPop = 10;
    public Transform spawnPoint;

    public float m_globalFrustration = 0;
    public float m_globalSuspicion = 0;

    //global sliders
    public Slider m_globalFrustrationSlider;
    public Slider m_globalSuspicionSlider;

    private Transform m_workerHolder;

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
        m_workerHolder = new GameObject("WorkerHolder").transform;
    }

    void Update()
    {
        m_globalFrustration = 0.0f;
        m_globalSuspicion = 0.0f;

        foreach (GameObject _worker in m_WorkerList)
        {
            m_globalFrustration += _worker.GetComponent<WorkerTally>().m_totalFrustration;
            m_globalSuspicion += _worker.GetComponent<WorkerTally>().m_totalSuspicion;
            _worker.GetComponent<AiMovement>().CheckGoal();
        }

        //constantly update global sliders
        m_globalFrustrationSlider.maxValue = 100.0f * WorkerManager.worker_instance.m_currentWorkerPop;
        m_globalSuspicionSlider.maxValue = 100.0f * WorkerManager.worker_instance.m_currentWorkerPop;

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
            temp.transform.SetParent(m_workerHolder);
           m_WorkerList.Add(temp);
            //And wait 1 second to spawn another
            yield return new WaitForSeconds(1f);
        }
        
    }
}
