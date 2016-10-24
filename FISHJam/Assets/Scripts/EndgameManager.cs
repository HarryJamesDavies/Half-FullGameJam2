using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndgameManager : MonoBehaviour {

    public Text m_endgameTitle;
    public Text m_frustrationValue;
    public Text m_suspicionValue;

    void Start()
    {
        Endgame();
    }

    void Endgame()
    {
        if (GameManager.m_gameManager.m_loseBool)
        {
            m_endgameTitle.text = "GAME OVER!";
        }
        else if (GameManager.m_gameManager.m_winBool)
        {
            m_endgameTitle.text = "YOU WON!";
        }

        m_frustrationValue.text = GameManager.m_gameManager.m_finalFrustration.ToString();
        m_suspicionValue.text = GameManager.m_gameManager.m_finalSuspicion.ToString();
    }
}
