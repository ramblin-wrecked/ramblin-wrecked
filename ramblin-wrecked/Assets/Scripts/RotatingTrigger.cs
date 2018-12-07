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
		amountRotated = 90f;
		turn = false;
		
	}

	// Update is called once per frame
	void Update () {
		if (turn == true) {
			float frameRotation = rotation_per_second * Time.deltaTime * -1f;
			Debug.Log ("FRAME ROTATION" + frameRotation);
			rotatingObject.transform.Rotate (0f, frameRotation, 0f);
			amountRotated += frameRotation;

			if (amountRotated <= 0f) {
				turn = false;
				amountRotated = 0f;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (!turn) {
				Debug.Log ("Object Entered the trigger");
				turn = true;
			}
		}
	}
}
