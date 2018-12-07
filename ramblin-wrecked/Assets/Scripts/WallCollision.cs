using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WallCollision : MonoBehaviour
{

    private BoxCollider bc;

    public SceneSwitchScript sceneSwapper;
    public int switchToLevel;
    public bool GameOver = false;

    void Awake()
    {
        bc = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            if (sceneSwapper != null)
            {
                switch (switchToLevel)
                {
                    case 1:
                        sceneSwapper.SwitchToLevel1();
                        break;
                    case 2:
                        sceneSwapper.SwitchToLevel2();
                        break;
                }
            }
            else if (!GameOver)
            {
                GameOver = true;
            }
        }
    }
}
