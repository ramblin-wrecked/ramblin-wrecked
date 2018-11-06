using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHit : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FixedPlayerMovement bc = c.attachedRigidbody.gameObject.GetComponent<FixedPlayerMovement>();
            if (bc != null)
            {
                bc.isDizzy = true;
                this.gameObject.SetActive(false);
            }
        }
    }

}
