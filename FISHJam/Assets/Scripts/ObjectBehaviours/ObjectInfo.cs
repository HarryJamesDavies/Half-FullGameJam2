using UnityEngine;
using System.Collections;

public class ObjectInfo : MonoBehaviour {

    public InteractableManager.ObjectType m_type;
    public float[] m_frustration;
    public float[] m_suspicion;

    public float GetFrustration()
    {
        return m_frustration[(int)gameObject.GetComponent<InteractableBase>().m_state];    
    }


    public float GetSuspicion()
    {
        return m_suspicion[(int)gameObject.GetComponent<InteractableBase>().m_state];
    }
}
