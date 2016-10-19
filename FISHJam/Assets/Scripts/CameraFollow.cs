using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    float m_zoomFactor = 0.3f;
    float m_movementFactor = 0.1f;
    public float m_zoomInFactor = 2.0f;
    public float m_zoomOutFactor = 8.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.mousePosition.x > 0.0f)
        {
            transform.position = new Vector3(transform.position.x + m_movementFactor, transform.position.y, transform.position.z);            
		}

        if (Input.mousePosition.x < Screen.width)
        {
            transform.position = new Vector3(transform.position.x - m_movementFactor, transform.position.y, transform.position.z);
        }

        if (Input.mousePosition.y > 0.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_movementFactor);
        }

        if (Input.mousePosition.y < Screen.height)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - m_movementFactor);
        }

        //to zoom the camera out
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + m_zoomFactor, transform.position.z);
            //chehck its y position
            if (transform.position.y > m_zoomOutFactor)
            {
                //then lock its position
                transform.position = new Vector3(transform.position.x, m_zoomOutFactor, transform.position.z);
            }
        }

        //to zoom the camera in
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - m_zoomFactor, transform.position.z);
            //check its y position
            if(transform.position.y < m_zoomInFactor)
            {
                //then lock its position
                transform.position = new Vector3(transform.position.x, m_zoomInFactor, transform.position.z);
            }
        }
	}
}
