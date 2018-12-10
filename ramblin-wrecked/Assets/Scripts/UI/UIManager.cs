using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class UIManager : MonoBehaviour {

    Animator anim;
    public WallCollision wallCollision;
    public WallCollision fallCollision;
    public WallCollision winWallCollision;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ToggleMenu"))
        {
            anim.SetTrigger("ToggleMenu");
            TimeKeeper.isPaused = !TimeKeeper.isPaused;
        }
        if (wallCollision.GameOver || (fallCollision != null && fallCollision.GameOver))
        {
            anim.SetTrigger("GameOver");
            TimeKeeper.isPaused = false;
        }
        if (winWallCollision != null && winWallCollision.GameOver)
        {
            anim.SetTrigger("Win");
            TimeKeeper.isPaused = false;
        }
	}
}
