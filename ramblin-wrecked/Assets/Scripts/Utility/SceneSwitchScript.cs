using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour {

	public void SwitchToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("Scenes/MainGame");
        TimeKeeper.notPaused = true;
    }

}
