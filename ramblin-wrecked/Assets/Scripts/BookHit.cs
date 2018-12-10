using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHit : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FixedPlayerMovement bc = c.attachedRigidbody.gameObject.GetComponent<FixedPlayerMovement>();
            if (bc != null)
            {
                bc.booksNum += 1;
                this.gameObject.SetActive(false);
            }
        }
    }
}
