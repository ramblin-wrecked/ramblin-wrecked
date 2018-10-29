using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class UIManager : MonoBehaviour {

    Animator anim;
    public WallCollision wallCollision;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ToggleMenu"))
            anim.SetTrigger("ToggleMenu");
        if (wallCollision.GameOver)
        {
            anim.SetTrigger("GameOver");
        }
	}



}
