using UnityEngine;
using System.Collections;

public class TableBehaviour : MonoBehaviour
{
    public Texture[] m_textures;

    private PlayerAbilities.InteractableStates m_state;
    private bool m_toggle = true;
    private GameObject m_screen;
    public int m_imageNum = 1;
    private int m_screenSaverNum = 1;
    private int m_activeScreen = 0;
    private bool m_modified = false;

    public float m_waitLength = 2.0f;
    private float m_changeStart = 0.0f;

    void Awake()
    {
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).tag == "Screen")
            {
                m_screen = transform.GetChild(i).gameObject;
            }
        }
    }

    void Update ()
    {
        if (GetComponent<InteractableBase>().m_active)
        {
            m_state = GetComponent<InteractableBase>().m_state;
            m_modified = false;
            ChangeBehaviour();
            GetComponent<InteractableBase>().m_active = false;
        }

        if(m_modified)
        {
            if(Time.time - m_changeStart >= m_waitLength)
            {
                m_imageNum++;
                if(m_imageNum >= m_textures.Length)
                {
                    m_imageNum = 2;
                }
                ChangeTexture(m_imageNum);
                m_changeStart = Time.time;
            }
        }
        else if(m_toggle && gameObject.GetComponent<InteractableBase>().m_inUse)
        {
            m_imageNum = m_activeScreen;
            ChangeTexture(m_imageNum);
        }
        else
        {
            m_imageNum = m_screenSaverNum;
            ChangeTexture(m_imageNum);
        }
    }

    void ChangeBehaviour()
    {
        if (m_state == PlayerAbilities.InteractableStates.NORMAL)
        {
            NormalBehaviour();
        }
        else if (m_state == PlayerAbilities.InteractableStates.TOGGLE)
        {
            ToggleBehaviour();
        }
        else if (m_state == PlayerAbilities.InteractableStates.SWAP)
        {
            SwapBehaviour();
        }
        else if (m_state == PlayerAbilities.InteractableStates.MODIFY)
        {
            ModifyBehaviour();
        }
    }

    void NormalBehaviour()
    {
        m_activeScreen = 0;
        m_screenSaverNum = 1;
    }

    void ToggleBehaviour()
    {
        if (m_toggle)
        {
            // m_screen.GetComponent<Renderer>().material.color = Color.black;
            m_imageNum = m_screenSaverNum;
            ChangeTexture(m_imageNum);
            m_toggle = false;
        }
        else
        {
            //m_screen.GetComponent<Renderer>().material.color = Color.blue;
            m_toggle = true;
        }
    }

    void SwapBehaviour()
    {
        m_activeScreen = 1;
        m_screenSaverNum = 0;
    }

    void ModifyBehaviour()
    {
        m_modified = true;
        m_imageNum = 2;
        ChangeTexture(m_imageNum);
        m_changeStart = Time.time;
    }

    void ChangeTexture(int i)
    {
        m_screen.GetComponent<Renderer>().material.mainTexture = m_textures[i];
    }
}
