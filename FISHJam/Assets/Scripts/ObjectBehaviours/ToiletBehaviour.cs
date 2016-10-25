using UnityEngine;
using System.Collections;

public class ToiletBehaviour : MonoBehaviour
{

    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    //private bool m_toggle = false;
    private GameObject particle;
    private bool m_toggle = false;



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
        if (!m_toggle)
        {
            if (gameObject.GetComponent<InteractableBase>().m_inUse)
            {
                m_animator.SetBool("m_triggered", true);
            }
            else
            {
                m_animator.SetBool("m_triggered", false);
            }
        }

        if (GetComponent<InteractableBase>().m_active)
        {
            ResetBehaviour();
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
        m_toggle = true;
        particle.SetActive(false);

    }

    void SwapBehaviour()
    {
        if (!m_animator.GetBool("m_broken"))
        {
            m_animator.SetBool("m_broken", true);
            particle.SetActive(true);
        }
        particle.SetActive(false);

    }

    void ModifyBehaviour()
    {
        if (!m_animator.GetBool("m_blocked"))
        {
            m_animator.SetBool("m_blocked", true);
        }
        particle.SetActive(false);
    }

    void ResetBehaviour()
    {
        m_state = GetComponent<InteractableBase>().m_state;

        m_animator.SetBool("m_blocked", false);
        m_animator.SetBool("m_broken", false);
        m_animator.SetBool("m_using", false);

        particle.SetActive(false);

        m_toggle = false;
    }
}
