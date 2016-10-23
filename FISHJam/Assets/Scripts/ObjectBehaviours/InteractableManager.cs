using UnityEngine;
using System;
using System.Collections.Generic;

public class InteractableManager : MonoBehaviour
{

    public enum ObjectType
    {
        TABLE = 0,
        DOOR = 1,
        WATERCOOLER = 2,
        TOILET = 3,
        PRINTER = 4,
        FRIDGE = 5
    }

    public static InteractableManager m_instance = null;
    public List<Transform> m_objectReferences = new List<Transform>();
    public Transform m_referenceHolder;

    // Use this for initialization
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_referenceHolder = new GameObject("ReferenceHolder").transform;
        GetObjects();
    }

    void LateUpdate()
    {
        foreach (Transform reference in m_objectReferences)
        {
            reference.GetComponent<ObjectReference>().UpdateObjectReference();
        }
    }

    //Gets all interactable objects in the scene and stores
    void GetObjects()
    {
        GameObject[] m_objects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject objects in m_objects)
        {
            Vector3 objectPosition = Vector3.zero;
            for (int i = 0; i <= objects.transform.childCount - 1; i++)
            {
                if (objects.transform.GetChild(i).tag == "NPCPosition")
                {
                    objectPosition = objects.transform.GetChild(i).transform.position;
                }
            }

            Transform temp = new GameObject("ObjectReference").transform;
            temp.transform.SetParent(m_referenceHolder);

            temp.gameObject.AddComponent<ObjectReference>();
            temp.gameObject.GetComponent<ObjectReference>().m_object = objects;
            temp.gameObject.GetComponent<ObjectReference>().m_type = objects.GetComponent<InteractableBase>().m_type;
            temp.gameObject.GetComponent<ObjectReference>().m_state = objects.GetComponent<InteractableBase>().m_state;
            temp.gameObject.GetComponent<ObjectReference>().m_position = objectPosition;
            temp.gameObject.GetComponent<ObjectReference>().m_inUse = objects.GetComponent<InteractableBase>().m_inUse;
            m_objectReferences.Add(temp);
        }
    }

    //Returns either the first object a type or the closet to a point, with the option to get one that is in use or free.
    public ObjectReference GetObjectOfType(ObjectType _type, bool _notInUse, bool _getClosest, Vector3 _NPCPosition)
    {
        Transform objectReference = null;
        List<Transform> referenceOfType = new List<Transform>();

        foreach (Transform reference in m_objectReferences)
        {
            if (reference.gameObject.GetComponent<ObjectReference>().m_type == _type)
            {
                referenceOfType.Add(reference);
            }
        }

        if (_notInUse)
        {
            foreach (Transform reference in referenceOfType)
            {
                if (reference.gameObject.GetComponent<ObjectReference>().m_inUse)
                {
                    referenceOfType.Remove(reference);
                }
            }
        }

        if (_getClosest)
        {
            float distance = 1000.0f;
            foreach (Transform reference in referenceOfType)
            {
                if (Vector3.Distance(_NPCPosition,
                    reference.gameObject.GetComponent<ObjectReference>().m_position) <= distance)
                {
                    distance = Vector3.Distance(_NPCPosition,
                        reference.gameObject.GetComponent<ObjectReference>().m_position);
                    objectReference = reference;
                }
            }
        }

        if (objectReference == null)
        {
            objectReference = referenceOfType[0]; //BREAKS HERE
        }

        foreach (Transform reference in referenceOfType)
        {
            if(objectReference != reference)
            {
                Destroy(reference.gameObject);
            }
        }

        return objectReference.gameObject.GetComponent<ObjectReference>();
    }
}
