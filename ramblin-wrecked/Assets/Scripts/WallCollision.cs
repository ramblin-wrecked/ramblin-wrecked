using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WallCollision : MonoBehaviour
{

    private BoxCollider bc;
    private AudioSource sfx;

    public SceneSwitchScript sceneSwapper;
    public Animator fadeOut;
    public float timeUntilFadeOut;

    public bool GameOver = false;

    void Awake()
    {
        bc = GetComponent<BoxCollider>();
        sfx = GetComponent<AudioSource>();
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(timeUntilFadeOut);

        fadeOut.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(1.0f);

        sceneSwapper.NextLevel();
        yield return null;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            if (sfx != null)
            {
                sfx.Play();
            }

            if (sceneSwapper != null)
            {
                FixedPlayerMovement pm = c.GetComponent<FixedPlayerMovement>();
                pm.GoNuts();

                StartCoroutine("LoadNextScene");

                /*switch (switchToLevel)
                {
                    case 1:
                        sceneSwapper.SwitchToLevel1();
                        break;
                    case 2:
                        sceneSwapper.SwitchToLevel2();
                        break;
                }*/
            }
            else if (!GameOver)
            {
                GameOver = true;
            }
        }
    }
}
