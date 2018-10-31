using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportDimensions : MonoBehaviour {

    Collider collider;
    public Vector3 dimensions;

	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
	}

    void Update()
    {
        dimensions = collider.bounds.max - collider.bounds.min;
    }
}
