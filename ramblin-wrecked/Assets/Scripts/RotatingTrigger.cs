using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrigger : MonoBehaviour {

	public GameObject rotatingObject;
	public float rotation_per_second = 45f / 3f;
	private float amountRotated;

	private bool turn;

	// Use this for initialization
	void Start () {
		amountRotated = 0f;
		turn = false;
		
	}

	// Update is called once per frame
	void Update () {
		if (turn == true) {
			float frameRotation = rotation_per_second * Time.deltaTime;
			rotatingObject.transform.Rotate (0f, frameRotation, 0f);
			amountRotated += frameRotation;

			if (amountRotated >= 90f) {
				turn = false;
				amountRotated = 0f;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!turn) {
			Debug.Log ("Object Entered the trigger");
			turn = true;
		}

	}


}
