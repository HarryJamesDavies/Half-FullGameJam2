using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    [Serializable]
    public enum  InteractableStates
    {
        NORMAL = 0,
        TOGGLE = 1,
        MODIFY = 2,
        SWAP = 3
    };

    public static PlayerAbilities instance = null;
    public GameObject m_currentInteractable = null;
    public InteractableStates m_state = InteractableStates.NORMAL;

    public Text m_abilityText;
    public Text m_objectState;
    public string m_currentAbility;
    public string m_stateOfObject;

    // Use this for initialization
    void Awake ()
    {
	    if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        m_currentAbility = "NORMAL";
        m_stateOfObject = "NORMAL";
        m_abilityText.text = m_currentAbility;
        m_objectState.text = m_stateOfObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.m_gameManager.m_useController)
        {
            switch (GameManager.m_gameManager.m_controllerType)
            {
                case "Xbox":
                    //Xbox controller ability changes

                    //Press A to change Toggle ability
                    if (Input.GetButtonDown("A"))
                    {
                        if (m_state != InteractableStates.TOGGLE)
                        {
                            m_state = InteractableStates.TOGGLE;
                            m_currentAbility = "TOGGLE";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press B to change Modify ability
                    if (Input.GetButtonDown("B"))
                    {
                        if (m_state != InteractableStates.MODIFY)
                        {
                            m_state = InteractableStates.MODIFY;
                            m_currentAbility = "MODIFY";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press X to change Swap ability
                    if (Input.GetButtonDown("X(Xbox)"))
                    {
                        if (m_state != InteractableStates.SWAP)
                        {
                            m_state = InteractableStates.SWAP;
                            m_currentAbility = "SWAP";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press Y to change ability to normal
                    if (Input.GetButtonDown("Y"))
                    {
                        m_state = InteractableStates.NORMAL;
                        m_currentAbility = "NORMAL";
                    }

                    //Press Right trigger to activate ability over an interactable object
                    if (m_currentInteractable != null)
                    {
                        if (Input.GetAxis("Triggers") < 0.0f)
                        {
                            Debug.Log("Right Trigger pulled");
                            m_currentInteractable.GetComponent<InteractableBase>().SetState(m_state);
                        }
                    }

                    break;
                case "PS4":
                    //PS4 controller ability changes

                    //Press X to change Toggle ability
                    if (Input.GetButtonDown("X(PS4)"))
                    {
                        if (m_state != InteractableStates.TOGGLE)
                        {
                            m_state = InteractableStates.TOGGLE;
                            m_currentAbility = "TOGGLE";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press Circle to change Modify ability
                    if (Input.GetButtonDown("Circle"))
                    {
                        if (m_state != InteractableStates.MODIFY)
                        {
                            m_state = InteractableStates.MODIFY;
                            m_currentAbility = "MODIFY";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press Square to change Swap ability
                    if (Input.GetButtonDown("Square"))
                    {
                        if (m_state != InteractableStates.SWAP)
                        {
                            m_state = InteractableStates.SWAP;
                            m_currentAbility = "SWAP";
                        }
                        else
                        {
                            m_state = InteractableStates.NORMAL;
                            m_currentAbility = "NORMAL";
                        }
                    }

                    //Press Triangle to change ability to normal
                    if (Input.GetButtonDown("Triangle"))
                    {
                        m_state = InteractableStates.NORMAL;
                        m_currentAbility = "NORMAL";
                    }

                    //Press R2 to activate ability over an interactable object
                    if (m_currentInteractable != null)
                    {
                        if (Input.GetAxis("R2") > -1.0f)
                        {
                            Debug.Log("R2 pulled");
                            m_currentInteractable.GetComponent<InteractableBase>().SetState(m_state);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (m_state != InteractableStates.TOGGLE)
                {
                    m_state = InteractableStates.TOGGLE;
                    m_currentAbility = "TOGGLE";
                }
                else
                {
                    m_state = InteractableStates.NORMAL;
                    m_currentAbility = "NORMAL";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (m_state != InteractableStates.MODIFY)
                {
                    m_state = InteractableStates.MODIFY;
                    m_currentAbility = "MODIFY";
                }
                else
                {
                    m_state = InteractableStates.NORMAL;
                    m_currentAbility = "NORMAL";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (m_state != InteractableStates.SWAP)
                {
                    m_state = InteractableStates.SWAP;
                    m_currentAbility = "SWAP";
                }
                else
                {
                    m_state = InteractableStates.NORMAL;
                    m_currentAbility = "NORMAL";
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                m_state = InteractableStates.NORMAL;
                m_currentAbility = "NORMAL";
            }

            if (m_currentInteractable != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_currentInteractable.GetComponent<InteractableBase>().SetState(m_state);
                }
            }
        }

        m_abilityText.text = m_currentAbility;
	}

    void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Interactable")
        {
            m_currentInteractable = _collider.gameObject;
        }
    }

    void OnTriggerExit(Collider _collider)
    {
        if (_collider.gameObject == m_currentInteractable)
        {
            m_currentInteractable = null;
        }
    }
}
