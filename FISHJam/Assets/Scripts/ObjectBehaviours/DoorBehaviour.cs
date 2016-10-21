using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour
{

    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    private bool m_open = false;

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

        if (m_animator.speed == 0.1f && m_state != PlayerAbilities.InteractableStates.MODIFY)
        {
            m_animator.speed = 2.0f;
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
        if (m_animator.GetBool("m_open"))
        {
            m_animator.SetBool("m_open", false);
        }
        else
        {
            m_animator.SetBool("m_open", true);
        }
    }

    void SwapBehaviour()
    {

    }

    void ModifyBehaviour()
    {
        m_animator.speed = 0.1f;
    }

    void OnTriggerEnter(Collider _collider)
    {
        if (m_state != PlayerAbilities.InteractableStates.TOGGLE)
        {
            if (m_state != PlayerAbilities.InteractableStates.SWAP)
            {
                m_animator.SetBool("m_open", true);
            }
            else
            {
                m_animator.SetBool("m_open", false);
            }
        }
    }

    void OnTriggerExit(Collider _collider)
    {
        if (m_state != PlayerAbilities.InteractableStates.TOGGLE)
        {
            if (m_state != PlayerAbilities.InteractableStates.SWAP)
            {
                m_animator.SetBool("m_open", false);
            }
            else
            {
                m_animator.SetBool("m_open", true);
            }
        }
    }
}
