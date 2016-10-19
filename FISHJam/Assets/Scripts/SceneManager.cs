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

    public void SettingsClick()
    {
        Application.LoadLevel(3);
    }

    public void QuitClick()
    {
        Application.Quit();
    }

    void Update()
    {
        switch (Application.loadedLevel)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
                break;
            default:
                break;
        }
    }
}
