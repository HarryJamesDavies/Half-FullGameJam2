using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    void Update()
    {
        //quit and menu buttons switch statement
        switch (Application.loadedLevel)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controls on both controllers for navigating the menu
                if (GameManager.m_gameManager.m_useController)
                {
                    if (GameManager.m_gameManager.m_controllerType == "Xbox")
                    {
                        if (Input.GetButtonDown("A"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("Y"))
                        {
                            Application.LoadLevel(2);
                            break;
                        }

                        if (Input.GetButtonDown("X(Xbox)"))
                        {
                            Application.LoadLevel(3);
                            break;
                        }

                        if (Input.GetButtonDown("Start"))
                        {
                            Application.Quit();
                            break;
                        }
                    }
                    else if (GameManager.m_gameManager.m_controllerType == "PS4")
                    {
                        if (Input.GetButtonDown("X(PS4)"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("Triangle"))
                        {
                            Application.LoadLevel(2);
                            break;
                        }

                        if (Input.GetButtonDown("Square"))
                        {
                            Application.LoadLevel(3);
                            break;
                        }

                        if (Input.GetButtonDown("TouchPad"))
                        {
                            Application.Quit();
                            break;
                        }
                    }
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controls on both controllers for navigating the menu
                if (GameManager.m_gameManager.m_useController)
                {
                    if (GameManager.m_gameManager.m_controllerType == "Xbox")
                    {
                        if (Input.GetButtonDown("Start"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                    else if (GameManager.m_gameManager.m_controllerType == "PS4")
                    {
                        if (Input.GetButtonDown("TouchPad"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controls on both controllers for navigating the menu
                if (GameManager.m_gameManager.m_useController)
                {
                    if (GameManager.m_gameManager.m_controllerType == "Xbox")
                    {
                        if (Input.GetButtonDown("A"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("X(Xbox)"))
                        {
                            Application.LoadLevel(3);
                            break;
                        }

                        if (Input.GetButtonDown("Start"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                    else if (GameManager.m_gameManager.m_controllerType == "PS4")
                    {
                        if (Input.GetButtonDown("X(PS4)"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("Square"))
                        {
                            Application.LoadLevel(3);
                            break;
                        }

                        if (Input.GetButtonDown("TouchPad"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controls on both controllers for navigating the menu
                if (GameManager.m_gameManager.m_useController)
                {
                    if (GameManager.m_gameManager.m_controllerType == "Xbox")
                    {
                        if (Input.GetButtonDown("A"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("Start"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                    else if (GameManager.m_gameManager.m_controllerType == "PS4")
                    {
                        if (Input.GetButtonDown("X(PS4)"))
                        {
                            Application.LoadLevel(1);
                            break;
                        }

                        if (Input.GetButtonDown("TouchPad"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }
                    }
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    break;
                }

                //controls on both controllers for navigating the menu
                if (GameManager.m_gameManager.m_useController)
                {
                    if (GameManager.m_gameManager.m_controllerType == "Xbox")
                    {
                        if (Input.GetButtonDown("B"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }

                        if (Input.GetButtonDown("Start"))
                        {
                            Application.Quit();
                            break;
                        }
                    }
                    else if (GameManager.m_gameManager.m_controllerType == "PS4")
                    {
                        if (Input.GetButtonDown("Circle"))
                        {
                            GameManager.m_gameManager.ResetGame();
                            Application.LoadLevel(0);
                            break;
                        }

                        if (Input.GetButtonDown("TouchPad"))
                        {
                            Application.Quit();
                            break;
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    //functions for all menu button presses
    public void MainMenuClick()
    {
        GameManager.m_gameManager.ResetGame();
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
}
