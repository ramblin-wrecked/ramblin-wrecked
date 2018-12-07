using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class InstructionsKeyLabel : MonoBehaviour {

    public string control;

	// Use this for initialization
	void Start () {
        TextMesh tm = GetComponent<TextMesh>();
	}
}
