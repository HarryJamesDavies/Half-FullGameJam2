using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager m_gameManager = null;

    public bool m_useController;

    void Awake()
    {
        m_useController = false;
        
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
}
