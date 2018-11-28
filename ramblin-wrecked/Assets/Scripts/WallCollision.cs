using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WallCollision : MonoBehaviour
{

    private BoxCollider bc;

    public SceneSwitchScript sceneSwapper;
    public bool GameOver = false;

    void Awake()
    {
        bc = GetComponent<BoxCollider>();

        if (bc == null)
        {
            Debug.Log("Box Collider could not be found");
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            if (sceneSwapper != null)
            {
                sceneSwapper.SwitchToGame();
            }
            else if (!GameOver)
            {
                GameOver = true;
            }
        }
    }
}
