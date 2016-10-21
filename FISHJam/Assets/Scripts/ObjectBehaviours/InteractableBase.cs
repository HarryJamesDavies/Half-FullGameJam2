using UnityEngine;
using System;
using System.Collections;

public class InteractableBase : MonoBehaviour
{
    public PlayerAbilities.InteractableStates m_state;
    public bool m_active = false; //Set true when apllying a new state
    public InteractableManager.ObjectType m_type; //Set in inspector to tag
    public bool m_inUse; //set ture when NPC is using it

    public void SetState(PlayerAbilities.InteractableStates _state)
    {
        m_state = _state;
        m_active = true;
    }

    public PlayerAbilities.InteractableStates GetState()
    {
        return m_state;
    }

    public String GetStateString()
    {
        string _string;
        switch (m_state)
        {
            case PlayerAbilities.InteractableStates.NORMAL:
            {
                    _string = "NORMAL";
                break;
            }
            case PlayerAbilities.InteractableStates.TOGGLE:
                {
                    _string = "TOGGLE";
                    break;
                }
            case PlayerAbilities.InteractableStates.MODIFY:
                {
                    _string = "MODIFY";
                    break;
                }
            case PlayerAbilities.InteractableStates.SWAP:
                {
                    _string = "SWAP";
                    break;
                }
            default:
                {
                    _string = "NORMAL";
                    break;
                }
        }

        return _string;
    }
}

//=============================================================//
//    This the base code for every object behaviour script     //
//=============================================================//

//private PlayerAbilities.InteractableStates m_state;
//private Animator m_animator;
//private bool m_toggle = false;

//void Awake()
//{
//    m_animator = GetComponent<Animator>();
//}
//
//void Update()
//{
//    if (GetComponent<InteractableBase>().m_active)
//    {
//        m_state = GetComponent<InteractableBase>().m_state;
//        ChangeBehaviour();
//        GetComponent<InteractableBase>().m_active = false;
//    }
//}

//void ChangeBehaviour()
//{
//    if (m_state == PlayerAbilities.InteractableStates.NORMAL)
//    {
//        NormalBehaviour();
//    }
//    else if (m_state == PlayerAbilities.InteractableStates.TOGGLE)
//    {
//        ToggleBehaviour();
//    }
//    else if (m_state == PlayerAbilities.InteractableStates.SWAP)
//    {
//        SwapBehaviour();
//    }
//    else if (m_state == PlayerAbilities.InteractableStates.MODIFY)
//    {
//        ModifyBehaviour();
//    }
//}

//void NormalBehaviour()
//{

//}

//void ToggleBehaviour()
//{
//    if (m_toggle)
//    {

//        m_toggle = false;
//    }
//    else
//    {

//        m_toggle = true;
//    }
//}

//void SwapBehaviour()
//{

//}

//void ModifyBehaviour()
//{

//}
