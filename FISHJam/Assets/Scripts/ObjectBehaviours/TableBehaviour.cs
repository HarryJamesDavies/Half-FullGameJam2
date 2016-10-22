using UnityEngine;
using System.Collections;

public class TableBehaviour : MonoBehaviour
{ 
    private PlayerAbilities.InteractableStates m_state;
    private bool m_toggle = true;

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
            gameObject.transform.GetChild(3).GetComponent<Renderer>().material.color = Color.blue;
            m_toggle = false;
        }
        else
        {
            gameObject.transform.GetChild(3).GetComponent<Renderer>().material.color = Color.green;
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
