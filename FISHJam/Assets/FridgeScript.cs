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

    }

    void ToggleBehaviour()
    {
        if (!m_animator.GetBool("m_working"))
        {
            m_animator.SetBool("m_working", true);
        }


    }

    void SwapBehaviour()
    {
        m_animator.SetBool("m_printerSpit", true);

        if (m_animator.GetBool("m_printerNWork"))
        {
            m_animator.SetBool("m_printerNWork", false);
        }
        if (m_animator.GetBool("m_printerWork"))
        {
            m_animator.SetBool("m_printerWork", false);
        }
        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
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
