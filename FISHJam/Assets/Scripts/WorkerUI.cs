using UnityEngine;
using System.Collections;

public class WorkerUI : MonoBehaviour {

    public Quaternion m_initialRoation;

	void Start ()
    {
        m_initialRoation = transform.rotation;
	}

    void Update()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
