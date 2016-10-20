using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 m_target;
    private float m_screenWidth;
    private float m_screenHeight;
    private Vector3 m_offset;

    void Awake()
    {
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;
        m_offset = new Vector3(m_screenWidth / 200, 0.0f, m_screenHeight / 200);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Input.mousePosition.x /100, 0.0f, Input.mousePosition.y / 100);
        transform.position -= m_offset;
        transform.position += new Vector3(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z);
    }
}

