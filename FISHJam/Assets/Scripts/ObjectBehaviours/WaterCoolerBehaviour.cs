using UnityEngine;
using System.Collections;

public class WaterCoolerBehaviour : MonoBehaviour {

    private PlayerAbilities.InteractableStates m_state;
    //private Animator m_animator;
    private bool m_toggle = false;

    void Awake()
    {
        //m_animator = GetComponent<Animator>();
    }

    void Update()
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

            m_toggle = false;
        }
        else
        {

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
