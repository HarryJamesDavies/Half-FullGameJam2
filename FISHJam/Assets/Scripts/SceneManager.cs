using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public void MainMenuClick()
    {
        Application.LoadLevel(0);
    }

	public void PlayClick()
    {
        Application.LoadLevel(1);
    }

    public void InstructionsClick()
    {
        Application.LoadLevel(2);
    }

    public void ControlsClick()
    {
        Application.LoadLevel(3);
    }

    public void QuitClick()
    {
        Application.Quit();
    }

    void Update()
    {
        //menu and quit button switch statement
        switch (Application.loadedLevel)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controller main menu inputs
                if (GameManager.m_gameManager.m_useController)
                {
                    if (Input.GetButtonDown("X(PS4)") || (Input.GetButtonDown("A")))
                    {
                        Debug.Log("X/A pressed.");
                        Application.LoadLevel(1);
                        break;
                    }

                    if (Input.GetButtonDown("Triangle") || (Input.GetButtonDown("Y")))
                    {
                        Application.LoadLevel(2);
                        break;
                    }

                    if (Input.GetButtonDown("Square") || (Input.GetButtonDown("X(Xbox)")))
                    {
                        Debug.Log("Square/X pressed.");
                        Application.LoadLevel(3);
                        break;
                    }

                    if (Input.GetButtonDown("TouchPad") || (Input.GetButtonDown("Start")))
                    {
                        Application.Quit();
                        break;
                    }
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                if (GameManager.m_gameManager.m_useController)
                {
                    if (Input.GetButtonDown("TouchPad") || (Input.GetButtonDown("Start")))
                    {
                        Application.LoadLevel(0);
                        break;
                    }
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                if (GameManager.m_gameManager.m_useController)
                {
                    if (Input.GetButtonDown("X(PS4)") || (Input.GetButtonDown("A")))
                    {
                        Application.LoadLevel(1);
                        break;
                    }

                    if (Input.GetButtonDown("Square") || (Input.GetButtonDown("X(Xbox)")))
                    {
                        Application.LoadLevel(3);
                        break;
                    }

                    if (Input.GetButtonDown("TouchPad") || (Input.GetButtonDown("Start")))
                    {
                        Application.LoadLevel(0);
                        break;
                    }
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                if (GameManager.m_gameManager.m_useController)
                {
                    if (Input.GetButtonDown("X(PS4)") || (Input.GetButtonDown("A")))
                    {
                        Application.LoadLevel(1);
                        break;
                    }

                    if (Input.GetButtonDown("TouchPad") || (Input.GetButtonDown("Start")))
                    {
                        Application.LoadLevel(0);
                        break;
                    }
                }
                break;
            default:
                break;
        }
    }
}
