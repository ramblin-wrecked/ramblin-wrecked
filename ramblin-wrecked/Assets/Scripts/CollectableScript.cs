using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    public int creditValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (true) // TODO check if colliding thing is player
        {
            GameState.credits += creditValue;
            // TODO animate?
            Destroy(gameObject);
        }
    }
}
