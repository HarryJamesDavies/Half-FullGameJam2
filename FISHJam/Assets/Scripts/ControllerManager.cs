using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

    private int m_joystickIterator;

    void Start ()
    {
        //show how long joystick list is
        Debug.Log(Input.GetJoystickNames().Length);
    }
	
	void Update ()
    {
        //used to make sure the useController bool doesn't flip between false and true
        m_joystickIterator = 0;

        //iterates through the entire joystick list and checks for controllers
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            //check name for PS4 controller
            if (Input.GetJoystickNames()[i] == "Wireless Controller")
            {
                GameManager.m_gameManager.m_useController = true;
                m_joystickIterator--;
            }
            //check name for X1 controller
            else if (Input.GetJoystickNames()[i] == "Controller (Xbox One For Windows)")
            {
                GameManager.m_gameManager.m_useController = true;
                m_joystickIterator--;
            }
            else
            {
                //iterate the variable if no controller found
                m_joystickIterator++;

                //check if the iterator is the same size as the joystick list
                if (m_joystickIterator >= Input.GetJoystickNames().Length)
                {
                    GameManager.m_gameManager.m_useController = false;
                }
            }
        }
    }
}
