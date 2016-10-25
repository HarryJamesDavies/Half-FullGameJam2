using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager m_gameManager = null;

    public bool m_useController;
    public string m_controllerType;

    //endgame variables
    public bool m_winBool;
    public bool m_loseBool;
    public bool m_endgame;

    public float m_finalFrustration;
    public float m_finalSuspicion;

    public float m_frustrationMultiplier;
    public float m_suspicionMultiplier;

    void Awake()
    {
        //setup of variables
        m_useController = false;
        m_controllerType = " ";

        m_winBool = false;
        m_loseBool = false;
        m_endgame = false;

        m_finalFrustration = 0.0f;
        m_finalSuspicion = 0.0f;

        //scaled down for demo version, actual values should be: 80.0f and 70.0f
        m_frustrationMultiplier = 40.0f;
        m_suspicionMultiplier = 30.0f;
        
        //make sure singleton is properly initialised
        if (m_gameManager == null)
        {
            m_gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //sets game manager to not be destroyed when changing scenes
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //constantly check if endgame has happened
        if(Application.loadedLevel == 1)
        {
            if (!m_endgame)
            {
                if (WorkerManager.worker_instance.m_globalFrustration > WorkerManager.worker_instance.m_currentWorkerPop * m_frustrationMultiplier &&
                    WorkerManager.worker_instance.m_globalSuspicion < WorkerManager.worker_instance.m_currentWorkerPop * m_suspicionMultiplier)
                {
                    m_loseBool = false;
                    m_winBool = true;

                    m_finalFrustration = WorkerManager.worker_instance.m_globalFrustration;
                    m_finalSuspicion = WorkerManager.worker_instance.m_globalSuspicion;

                    m_endgame = true;

                    Application.LoadLevel(4);
                }

                if (WorkerManager.worker_instance.m_globalSuspicion > WorkerManager.worker_instance.m_currentWorkerPop * m_suspicionMultiplier)
                {
                    m_loseBool = true;
                    m_winBool = false;

                    m_finalFrustration = WorkerManager.worker_instance.m_globalFrustration;
                    m_finalSuspicion = WorkerManager.worker_instance.m_globalSuspicion;

                    m_endgame = true;

                    Application.LoadLevel(4);
                }
            }
        }
    }

    public void ResetGame()
    {
        m_winBool = false;
        m_loseBool = false;
        m_endgame = false;

        m_finalFrustration = 0.0f;
        m_finalSuspicion = 0.0f;
    }
}
