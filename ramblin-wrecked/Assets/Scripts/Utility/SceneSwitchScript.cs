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

    public void ReloadLevel()
    {
        switch (level)
        {
            case 1:
                SwitchToLevel1();
                break;
            case 2:
                SwitchToLevel2();
                break;
        }
    }

    public void ReloadLevelWithDelay(float delayBy)
    {
        StartCoroutine("DelayedReloadLevel", delayBy);
    }

    IEnumerator DelayedReloadLevel(float delayBy)
    {
        yield return new WaitForSecondsRealtime(delayBy);

        ReloadLevel();
        yield return null;
    }

    public void NextLevel()
    {
        switch (level)
        {
            case 1:
                SwitchToLevel2();
                break;
            default:
                SwitchToLevel1();
                break;
        }
    }

    public void NextLevelWithDelay(float delayBy)
    {
        StartCoroutine("DelayedNextLevel", delayBy);
    }

    IEnumerator DelayedNextLevel(float delayBy)
    {
        yield return new WaitForSecondsRealtime(delayBy);

        NextLevel();
        yield return null;
    }

}
