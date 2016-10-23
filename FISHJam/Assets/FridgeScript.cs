using UnityEngine;
using System.Collections;

public class FridgeScript : MonoBehaviour {

    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    private bool m_toggle = false;

    //public ParticleSystem particles;

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
        if (m_animator.GetBool("m_working"))
        {
            m_animator.SetBool("m_working", false);
        }
        if (m_animator.GetBool("m_nworking"))
        {
            m_animator.SetBool("m_nworking", false);
        }
        if (m_animator.GetBool("m_swap"))
        {
            m_animator.SetBool("m_swap", false);
        }

    }

    void ToggleBehaviour()
    {
        if (!m_animator.GetBool("m_working"))
        {
            m_animator.SetBool("m_working", true);
        }
        if (!m_animator.GetBool("m_nworking"))
        {
            m_animator.SetBool("m_nworking", false);
        }
        if (m_animator.GetBool("m_swap"))
        {
            m_animator.SetBool("m_swap", false);
        }


    }

    void SwapBehaviour()
    {
        if (!m_animator.GetBool("m_swap"))
        {
            m_animator.SetBool("m_swap", true);
        }
        if (!m_animator.GetBool("m_nworking"))
        {
            m_animator.SetBool("m_nworking", false);
        }
        if (!m_animator.GetBool("m_working"))
        {
            m_animator.SetBool("m_working", false);
        }

    }

    void ModifyBehaviour()
    {
        if (m_animator.GetBool("m_working"))
        {
            m_animator.SetBool("m_working", false);
        }
        if (!m_animator.GetBool("m_nworking"))
        {
            m_animator.SetBool("m_nworking", true);
        }

    }
}
