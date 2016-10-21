using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerScript : MonoBehaviour {

    [SerializeField]
    public List<string> m_DesireList;

    private string m_thirsty;
    private string m_hungry;
    private string m_print;
    private string m_toilet;
    string m_currentDesire;

    //a random list position
    private static int m_randomListPosition;

    void start()
    {
        WorkerManager.worker_instance.AddGameObject(gameObject);
        SendWorkerToDesire();
    }

    void Awake()
    {
        m_DesireList = new List<string>();
        m_thirsty = "thirsty";
        m_hungry = "hungry";
        m_print = "print";
        m_toilet = "toilet";

        AddDesireToList();
        GetRandomListPosition();
        AssignDesireToWorker();
        SendWorkerToDesire();
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(10);

        Debug.Log("Time is up");
    }

    private void AddDesireToList()
    {
        m_DesireList.Add(m_thirsty);
        m_DesireList.Add(m_hungry);
        m_DesireList.Add(m_print);
        m_DesireList.Add(m_toilet);
    }

    private void GetRandomListPosition()
    {
        m_randomListPosition = Random.Range(0, m_DesireList.Count);
    }

    private void AssignDesireToWorker()
    {
        m_currentDesire = m_DesireList[m_randomListPosition];
        Debug.Log(m_currentDesire);
    }

    private void SendWorkerToDesire()
    {
        if (m_currentDesire == m_thirsty)
        {
            //starts a timer that will run for the length of time the task must be carried out 
            StartCoroutine("ExecuteAfterTime");

            //send worker to drinks station
        }
        if (m_currentDesire == m_hungry)
        {
            //starts a timer that will run for the length of time the task must be carried out 
            StartCoroutine("ExecuteAfterTime");

            //send worker to canteen
        }
        if (m_currentDesire == m_toilet)
        {
            //starts a timer that will run for the length of time the task must be carried out 
            StartCoroutine("ExecuteAfterTime");

            //send worker to toilets
        }
        if (m_currentDesire == m_print)
        {
            //starts a timer that will run for the length of time the task must be carried out 
            StartCoroutine("ExecuteAfterTime");

            //send worker to printer
        }

    }

}