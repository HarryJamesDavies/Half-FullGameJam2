using UnityEngine;
using System.Collections;

public class PrinterScript : MonoBehaviour {

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


    }

    void SwapBehaviour()
    {
        if (!m_animator.GetBool("m_printerSpit"))
        {
            m_animator.SetBool("m_printerSpit", true);
        }

    }

    void ModifyBehaviour()
    {
        if (!m_animator.GetBool("m_printerNWork"))
        {
            m_animator.SetBool("m_printerNWork", true);
        }

    }

    void ResetBehaviour()
    {
        m_state = GetComponent<InteractableBase>().m_state;

        m_animator.SetBool("m_printerWorking", false);
        m_animator.SetBool("m_printerNWork", false);
        m_animator.SetBool("m_printerSpit", false);
        m_animator.SetBool("m_prinerNorm", false);

        m_toggle = false;
    }
}
