using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerScript : MonoBehaviour {

    [SerializeField]
    public List<string> m_DesireList;

    private string m_thirsty;
    private string m_hungry;
    private static int m_randomListPosition;

    void start()
    {
        WorkerManager.worker_instance.AddGameObject(gameObject);
    }

    void Awake ()
    {
        m_DesireList = new List<string>();
        m_thirsty = "thirsty";
        m_hungry = "hungry";

        AddDesireToList();
        GetRandomListPosition();

    }

    private void AddDesireToList()
    {
        m_DesireList.Add(m_thirsty);
        m_DesireList.Add(m_hungry);
    }

    private void GetRandomListPosition()
    {
        int m_randomListPosition = Random.Range(0, 2);
        Debug.Log(m_randomListPosition);
    }

}







//add all of the desires to the list 

//select a random desire for each worker
//move towards desire
//start a timer to acheieve the desire

//if the desire has not been achieved 
//start incrementing annoyance 

//if the desire has been acheievd 
//decrement annoyance

// Use this for initialization