using UnityEngine;
using System.Collections;

public class NPCDetector : MonoBehaviour {

	void OnTriggerEnter(Collider _other)
    {
        GetComponentInParent<InteractableBase>().m_inUse = true;
    }

    void OnTriggerExit(Collider _other)
    {
        GetComponentInParent<InteractableBase>().m_inUse = false;
    }
}
