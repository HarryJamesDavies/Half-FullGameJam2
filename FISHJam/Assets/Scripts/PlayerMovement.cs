using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 m_target;
    public Camera m_camera;
    public bool m_followMouse;
    public bool m_playerAccelerates;
    public float m_playerSpeed = 2.0f;
    public float m_screenWidth;
    public float m_screenHeight;
    public Vector3 m_offset;

    void Awake()
    {
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;
        m_offset = new Vector3(m_screenWidth / 200, 0.0f, m_screenHeight / 200);
    }

    void LateUpdate()
    {
        if (m_followMouse)
        {
            m_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_target.y = transform.position.y;
        }
        

        float delta = m_playerSpeed * Time.deltaTime;
        if (m_playerAccelerates)
        {
            delta *= Vector3.Distance(transform.position, m_target);
        }

        transform.position = new Vector3(Input.mousePosition.x /100, 0.0f,Input.mousePosition.y / 100);//Vector3.MoveTowards(transform.position, m_target, delta);
        //transform.position -= new Vector3(6.0f, 0.0f, 3.0f);
        transform.position -= m_offset;
        transform.position += new Vector3(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z);
        string pos = m_target.x + ", " + m_target. y + ", " + m_target.z;
        string mouse =Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z;
        //Debug.Log(pos);
        Debug.Log(mouse);
    }
}

