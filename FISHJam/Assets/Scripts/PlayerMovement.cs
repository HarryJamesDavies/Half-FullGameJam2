using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 m_target;
    private float m_screenWidth;
    private float m_screenHeight;
    private float m_speed;
    private Vector3 m_offset;

    void Awake()
    {
        //initialise variables
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;
        m_speed = 0.1f;
        m_offset = new Vector3(m_screenWidth / 20, 0.0f, m_screenHeight / 20);
    }

    void LateUpdate()
    {
        //checks if controller is plugged in and applies correct player movement
        if (GameManager.m_gameManager.m_useController)
        {
            //constantly apply joystick axis input to player position
            transform.position += new Vector3(Input.GetAxis("LeftJoystickX") * m_speed, 0.0f, -Input.GetAxis("LeftJoystickY") * m_speed);
            //transform.position += new Vector3(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z);
        }
        else
        {
            //apply player position to mouse position and move player with camera
            transform.position = new Vector3(Input.mousePosition.x / 10, 0.0f, Input.mousePosition.y / 10);
            transform.position -= m_offset;
            transform.position += new Vector3(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z);
        }
    }
}

