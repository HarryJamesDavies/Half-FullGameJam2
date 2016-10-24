 using UnityEngine;
using System.Collections;

public class NPCDetector : MonoBehaviour {

	void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "NPC")
        {
            GetComponentInParent<InteractableBase>().m_inUse = true;
        }
    }

    void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.tag == "NPC")
        {
            GetComponentInParent<InteractableBase>().m_inUse = false;
        }
    }
}
