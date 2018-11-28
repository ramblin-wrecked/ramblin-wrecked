using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour {

    public int level = 0;

	public void SwitchToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void SwitchToGame()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("Scenes/MainGame");
        } else if (level == 1)
        {
            SceneManager.LoadScene("Scenes/SecondYear");
        }
    }

    public void SwitchToHowTo()
    {
        SceneManager.LoadScene("Scenes/HowTo");
    }

}
