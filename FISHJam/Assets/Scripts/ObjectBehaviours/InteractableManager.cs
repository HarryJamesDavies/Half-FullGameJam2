using UnityEngine;
using System;
using System.Collections.Generic;

public class InteractableManager : MonoBehaviour {

    public enum ObjectType
    {
        TABLE = 0,
        DOOR = 1,
        WATERCOOLER = 2,
        TOILET = 3
    }

    public static InteractableManager m_instance = null;
    public List<ObjectReference> m_objectReferences = new List<ObjectReference>();

    // Use this for initialization
    void Awake ()
    {
	    if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GetObjects();
    }


    //Gets all interactable objects in the scene and stores
    void GetObjects()
    {
        GameObject[] m_objects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(GameObject objects in m_objects)
        {
            Vector3 objectPosition =  Vector3.zero;
            for(int i = 0; i <= objects.transform.childCount - 1; i++)
            {
                if(objects.transform.GetChild(i).tag == "NPCPosition")
                {
                    objectPosition = objects.transform.GetChild(i).transform.position;
                }
            }

            m_objectReferences.Add(new ObjectReference(objects, objects.GetComponent<InteractableBase>().m_type, 
                objects.GetComponent<InteractableBase>().m_state, objectPosition, objects.GetComponent<InteractableBase>().m_inUse));
        }
    }

    //Returns either the first object a type or the closet to a point, with the option to get one that is in use or free.
	public ObjectReference GetObjectOfType(ObjectType _type, bool _notInUse, bool _getClosest, Vector3 _NPCPosition)
    {
        ObjectReference objectReference = null;
        List<ObjectReference> referenceOfType = new List<ObjectReference>();

        foreach (ObjectReference reference in m_objectReferences)
        {
            if(reference.m_type == _type)
            {
                referenceOfType.Add(reference);
            }
        }

        if (_notInUse)
        {
            foreach (ObjectReference reference in referenceOfType)
            {
                if (reference.m_inUse)
                {
                    referenceOfType.Remove(reference);
                }
            }
        }

        if(_getClosest)
        {
            float distance = 1000.0f;
            foreach(ObjectReference reference in referenceOfType)
            {
                if(Vector3.Distance(_NPCPosition, reference.m_position) <= distance)
                {
                    distance = Vector3.Distance(_NPCPosition, reference.m_position);
                    objectReference = reference;
                }
            }
        }

        if(objectReference == null)
        {
            objectReference = referenceOfType[0];
        }

        return objectReference;
    }
}
