using UnityEngine;
using System.Collections;

public class ToiletBehaviour : MonoBehaviour {

    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    private bool m_toggle = false;
    private GameObject particle;

    //public ParticleSystem particles;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).name == "WaterParticleSystem")
            {
                particle = transform.GetChild(i).gameObject;
            }
        }

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
        if (m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", false);
        }
        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
        }
        if (m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", false);
        }
        particle.SetActive(false);

    }

    void ToggleBehaviour()
    {
        if (!m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", true);
        }
        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
        }
        if (m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", false);
        }
        particle.SetActive(false);


    }

    void SwapBehaviour()
    {
        if (m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", false);
        }
        if (m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", false);
        }
        if (!m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", true);
        }
        particle.SetActive(false);

    }

    void ModifyBehaviour()
    {
        if (m_animator.GetBool("m_using"))
        {
            m_animator.SetBool("m_using", false);
        }
        if (!m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", true);
        }
        if (!m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", false);
        }
        particle.SetActive(true);
    }
}
