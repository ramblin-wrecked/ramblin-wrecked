using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHit : MonoBehaviour {

    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            CheckCup bc = c.attachedRigidbody.gameObject.GetComponent<CheckCup>();
            if (bc != null)
            {
                bc.isHit();
                this.gameObject.SetActive(false);
            }
        }
    }

}
