using UnityEngine;
using System;
using System.Collections;

public class ObjectReference : MonoBehaviour
{
    public GameObject m_object { get; set; }
    public InteractableManager.ObjectType m_type { get; set; }
    public PlayerAbilities.InteractableStates m_state { get; set; }
    public Vector3 m_position { get; set; }
    public bool m_inUse { get; set; }

    public ObjectReference(GameObject _object, InteractableManager.ObjectType _type, 
        PlayerAbilities.InteractableStates _state, Vector3 _position, bool _inUse)
    {
        m_object = _object;
        m_type = _type;
        m_state = _state;
        m_position = _position;
        m_inUse = _inUse;
    }
}
