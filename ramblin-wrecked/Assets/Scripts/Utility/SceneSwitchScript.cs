using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour {

    public int level = 0;

    void Switch(string sceneFilepath)
    {
        SceneManager.LoadScene(sceneFilepath);
    }

	public void SwitchToMainMenu()
    {
        Switch("Scenes/MainMenu");
    }

    public void SwitchToLevel1()
    {
        Switch("Scenes/MainGame");
    }

    public void SwitchToLevel2()
    {
        Switch("Scenes/SecondYear");
    }

    public void SwitchToHowTo()
    {
        SceneManager.LoadScene("Scenes/HowTo");
    }

    public void SwitchToGame()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("Scenes/MainGame");
        }
        else if (level == 1)
        {
            SceneManager.LoadScene("Scenes/SecondYear");
        }
    }

}
