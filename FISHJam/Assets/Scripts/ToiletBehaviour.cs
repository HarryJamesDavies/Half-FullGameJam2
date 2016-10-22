using UnityEngine;
using System.Collections;

public class ToiletBehaviour : MonoBehaviour {

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
        m_animator.SetBool("m_using", true); //active

        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
        }
        if (m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", false);
        }

    }

    void ToggleBehaviour()
    {
        m_animator.SetBool("m_using", false);
        m_animator.SetBool("m_broken", true);

        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", true);
        }
        else
        {
            m_animator.SetBool("m_using", true);
        }

    }

    void SwapBehaviour()
    {
        m_animator.SetBool("m_blocked", true);

        if (m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", false);
        }
        if (m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", false);
        }
        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
        }

    }

    void ModifyBehaviour()
    {

    }
}
