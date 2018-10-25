using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    Vector3 movement;
    public float speed;

	// Use this for initialization
	void Start () {
        movement = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + movement * speed;
	}
}
