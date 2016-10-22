using UnityEngine;
using System.Collections;

public class TableBehaviour : MonoBehaviour
{ 
    private PlayerAbilities.InteractableStates m_state;
    private bool m_toggle = true;
    private GameObject m_screen;
    public int m_imageNum = 0;
    public Texture[] m_textures;

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
            ChangeBehaviour();
            GetComponent<InteractableBase>().m_active = false;
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

    }

    void ToggleBehaviour()
    {
        if (m_toggle)
        {
          // m_screen.GetComponent<Renderer>().material.color = Color.black;
            m_screen.GetComponent<Renderer>().material.mainTexture = m_textures[1];
            m_toggle = false;
        }
        else
        {
            //m_screen.GetComponent<Renderer>().material.color = Color.blue;
            m_screen.GetComponent<Renderer>().material.mainTexture = m_textures[0];
            m_toggle = true;
        }
    }

    void SwapBehaviour()
    {

    }

    void ModifyBehaviour()
    {

    }
}
