using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerScript : MonoBehaviour {

    [SerializeField]
    public List<string> m_DesireList;
    public GameObject m_currentObject = null;

    private string m_thirsty;
    private string m_hungry;
    private string m_print;
    private string m_toilet;
    private string m_desk;
    public string m_currentDesire;

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
        m_desk = "desk";

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
        m_DesireList.Add(m_desk);
    }

    private void GetRandomListPosition()
    {
        m_randomListPosition = Random.Range(0, m_DesireList.Count);
    }

    public string AssignDesireToWorker()
    {
       return m_currentDesire = m_DesireList[m_randomListPosition];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPCPosition")
        {
            m_currentObject = other.transform.parent.gameObject;
        }
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