using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

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
}
