using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookThrow : MonoBehaviour {

    private GameObject Cuppy;
    //private GameObject targetPlayer;
    void Start()
    {
        Cuppy = this.transform.GetChild(0).gameObject; //Book obj not default
        Cuppy.gameObject.SetActive(false);
        //targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Cuppy.gameObject.SetActive(true);
            Cuppy.GetComponent<Animator>().SetTrigger("Throw");
        }


    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Cuppy.GetComponent<Animator>().SetTrigger("EndThrow");
            Cuppy.gameObject.SetActive(false);

        }
        CheckBook bc = c.attachedRigidbody.gameObject.GetComponent<CheckBook>();
        if (bc != null)
        {
            bc.outOfBox();
            GameObject def = Cuppy.transform.GetChild(0).gameObject; //default shape
            def.gameObject.SetActive(true);
        }
    }
}
