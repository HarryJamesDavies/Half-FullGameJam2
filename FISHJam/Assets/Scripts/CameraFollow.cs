using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    float m_zoomFactor = 5.0f;
    float m_movementFactor = 3.0f;
    float m_zoomInFactor = 20.0f;
    float m_zoomOutFactor = 60.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //checks if controller is plugged in
        if (GameManager.m_gameManager.m_useController)
        {
            switch (GameManager.m_gameManager.m_controllerType)
            {
                case "Xbox":
                    //camera moves as the player uses the right stick
                    transform.position += new Vector3(Input.GetAxis("RightJoystickX(Xbox)") * m_movementFactor, 0.0f,
                        -Input.GetAxis("RightJoystickY(Xbox)") * m_movementFactor);

                    //zoom in camera
                    if (Input.GetButtonDown("RightBumper"))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - m_zoomFactor, transform.position.z);
                        //check its y position
                        if (transform.position.y < m_zoomInFactor)
                        {
                            //then lock its position
                            transform.position = new Vector3(transform.position.x, m_zoomInFactor, transform.position.z);
                        }
                    }

                    //zoom out camera
                    if (Input.GetButtonDown("LeftBumper"))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + m_zoomFactor, transform.position.z);
                        //check its y position
                        if (transform.position.y > m_zoomOutFactor)
                        {
                            //then lock its position
                            transform.position = new Vector3(transform.position.x, m_zoomOutFactor, transform.position.z);
                        }
                    }
                    break;
                case "PS4":
                    //camera moves as the player uses the right stick
                    transform.position += new Vector3(Input.GetAxis("RightJoystickX(PS4)") * m_movementFactor, 0.0f,
                        -Input.GetAxis("RightJoystickY(PS4)") * m_movementFactor);

                    //zoom in camera
                    if (Input.GetButtonDown("R1"))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - m_zoomFactor, transform.position.z);
                        //check its y position
                        if (transform.position.y < m_zoomInFactor)
                        {
                            //then lock its position
                            transform.position = new Vector3(transform.position.x, m_zoomInFactor, transform.position.z);
                        }
                    }

                    //zoom out camera
                    if (Input.GetButtonDown("L1"))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + m_zoomFactor, transform.position.z);
                        //check its y position
                        if (transform.position.y > m_zoomOutFactor)
                        {
                            //then lock its position
                            transform.position = new Vector3(transform.position.x, m_zoomOutFactor, transform.position.z);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (Input.mousePosition.x > 0.0f)
            {
                transform.position = new Vector3(transform.position.x + m_movementFactor, transform.position.y, transform.position.z);
            }

            if (Input.mousePosition.x < Screen.width - 10.0f)
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
                //check its y position
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
                if (transform.position.y < m_zoomInFactor)
                {
                    //then lock its position
                    transform.position = new Vector3(transform.position.x, m_zoomInFactor, transform.position.z);
                }
            }
        }
	}
}
