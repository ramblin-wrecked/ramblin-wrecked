using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    Vector3 movementX;
    Vector3 movementY;
    Vector3 movementZ;
    public float speedX = 0;
    public float speedY = 0;
    public float speedZ = 0;

	// Use this for initialization
	void Start () {
        movementX = new Vector3(1, 0, 0);
        movementY = new Vector3(0, 1, 0);
        movementZ = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + movementZ * speedZ + movementX * speedX + movementY * speedY;
	}
}
