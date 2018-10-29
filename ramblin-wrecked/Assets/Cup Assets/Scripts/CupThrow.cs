using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupThrow : MonoBehaviour {

    private GameObject Cuppy;
    void Start()
    {
        Cuppy = this.transform.GetChild(0).gameObject; //Cup obj not default
        Cuppy.gameObject.SetActive(false);

    }


    private void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            Cuppy.gameObject.SetActive(true);
            Cuppy.GetComponent<Animator>().SetTrigger("Throw");
            
        }

    }

    private void OnTriggerExit(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            Cuppy.GetComponent<Animator>().SetTrigger("EndThrow");
            Cuppy.gameObject.SetActive(false);

            CheckCup bc = c.attachedRigidbody.gameObject.GetComponent<CheckCup>();
            if (bc != null)
            {
                bc.outOfBox();
                GameObject def = Cuppy.transform.GetChild(0).gameObject; //default shape
                def.gameObject.SetActive(true);
            }
        }
    }
}
