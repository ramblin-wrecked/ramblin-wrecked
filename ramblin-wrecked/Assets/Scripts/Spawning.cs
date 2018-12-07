using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Spawning : MonoBehaviour {

    public Transform toSpawn;
    public Vector3 pos;

    BoxCollider col;

    private void Awake()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            toSpawn.position = pos;
            col.enabled = false;
            Debug.Log("Triggered.");
        }
    }
}
