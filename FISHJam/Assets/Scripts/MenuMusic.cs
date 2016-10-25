using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

    public static MenuMusic m_musicInstance;

	// Use this for initialization
	void Start ()
    {
        if (m_musicInstance == null)
        {
            m_musicInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if (Application.loadedLevel == 1)
        {
            Destroy(this.gameObject);
        }
	}
}
