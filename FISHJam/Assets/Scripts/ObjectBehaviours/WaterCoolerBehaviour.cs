using UnityEngine;
using System.Collections;

public class WaterCoolerBehaviour : MonoBehaviour
{
    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    private bool m_toggle = false;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
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
        m_animator.SetBool("Active", true);
        m_animator.SetBool("Swap", false);
    }

    void ToggleBehaviour()
    {
        m_animator.SetBool("Swap", false);

        if (m_animator.GetBool("Active"))
        {
            m_animator.SetBool("Active", false);
        }
        else
        {
            m_animator.SetBool("Active", true);
        }
    }

    void SwapBehaviour()
    {
        m_animator.SetBool("Active", true);

        if (m_animator.GetBool("Swap"))
        {
            m_animator.SetBool("Swap", false);
        }
        else
        {
            m_animator.SetBool("Swap", true);
        }
    }

    void ModifyBehaviour()
    {

    }
}
