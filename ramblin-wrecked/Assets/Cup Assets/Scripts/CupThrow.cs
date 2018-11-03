using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupThrow : MonoBehaviour {

    private GameObject Cuppy;
    //private GameObject targetPlayer;
    void Start()
    {
        Cuppy = this.transform.GetChild(0).gameObject; //Cup obj not default
        Cuppy.gameObject.SetActive(false);
        //targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Cuppy.gameObject.SetActive(true);
            Cuppy.GetComponent<Animator>().SetTrigger("Throw");
            //Cuppy.GetComponent<Animator>().MatchTarget(targetPlayer.transform.position, targetPlayer.transform.rotation, AvatarTarget.Body, new MatchTargetWeightMask(Vector3.one, 1f), 0.141f, 0.78f);
        }


    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
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
