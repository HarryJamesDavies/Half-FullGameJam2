using UnityEngine;
using System.Collections;

public class WaterCoolerBehaviour : MonoBehaviour
{
    private PlayerAbilities.InteractableStates m_state;
    private Animator m_animator;
    private bool m_toggle = false;

    private GameObject m_sprayWater;
    private GameObject m_floorWater;

    void Awake()
    {
        m_animator = GetComponent<Animator>();

        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).name == "WaterParticles")
            {
                m_sprayWater = transform.GetChild(i).gameObject;
            }
            else if(transform.GetChild(i).name == "FloorWaterParticles")
            {
                m_floorWater = transform.GetChild(i).gameObject;
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
                m_animator.SetBool("m_active", true);
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
        ResetBehaviour();
    }

    void ToggleBehaviour()
    {
        if (!m_toggle)
        {
            ResetBehaviour();
            m_toggle = true;
            m_animator.SetBool("m_triggered", false);
        }
    }

    void SwapBehaviour()
    {
        if (m_animator.GetBool("m_swap"))
        {
            ResetBehaviour();
        }
        else
        {
            m_animator.SetBool("m_active", true);
            m_animator.SetBool("m_swap", true);
        }

    }

    void ModifyBehaviour()
    {
        m_animator.SetBool("m_spray", true);
    }

    void ResetBehaviour()
    {
        m_state = GetComponent<InteractableBase>().m_state;
        m_sprayWater.SetActive(false);
        m_floorWater.SetActive(false);
        m_animator.SetBool("m_swap", false);
        m_animator.SetBool("m_spray", false);
        m_toggle = false;
    }
}
