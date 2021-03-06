﻿using UnityEngine;
using System;
using System.Collections;

public class ObjectReference : MonoBehaviour
{
    public GameObject m_object { get; set; }
    public InteractableManager.ObjectType m_type { get; set; }
    public PlayerAbilities.InteractableStates m_state { get; set; }
    public Vector3 m_position { get; set; }
    public bool m_inUse { get; set; }
    public bool m_tagged { get; set; }

    void LateUpdate()
    {
        m_tagged = false;
    }

    public ObjectReference(GameObject _object, InteractableManager.ObjectType _type, 
        PlayerAbilities.InteractableStates _state, Vector3 _position, bool _inUse)
    {
        m_object = _object;
        m_type = _type;
        m_state = _state;
        m_position = _position;
        m_inUse = _inUse;
        m_tagged = false;
    }

    public void UpdateObjectReference()
    {
        if(m_type != m_object.GetComponent<InteractableBase>().m_type)
        {
            m_type = m_object.GetComponent<InteractableBase>().m_type;
        }

        if (m_state != m_object.GetComponent<InteractableBase>().m_state)
        {
            m_state = m_object.GetComponent<InteractableBase>().m_state;
        }

        if (m_position != m_object.transform.position)
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                if (transform.GetChild(i).tag == "NPCPosition")
                {
                    m_position = transform.GetChild(i).transform.position;
                }
            }
        }

        if (m_inUse != m_object.GetComponent<InteractableBase>().m_inUse)
        {
            m_inUse = m_object.GetComponent<InteractableBase>().m_inUse;
        }
    }
}
