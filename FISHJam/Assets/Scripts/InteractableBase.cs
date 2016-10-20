using UnityEngine;
using System.Collections;

public class InteractableBase : MonoBehaviour {

    public PlayerAbilities.InteractableStates m_state;

    public void SetState(PlayerAbilities.InteractableStates _state)
    {
        m_state = _state;
    }
}
