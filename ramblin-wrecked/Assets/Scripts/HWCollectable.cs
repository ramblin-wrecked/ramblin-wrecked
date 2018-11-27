using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Animator))]
public class HWCollectable : MonoBehaviour {
    Animator anim;
    Transform trans;

    private void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player") 
        {
            FixedPlayerMovement bc = c.attachedRigidbody.gameObject.GetComponent<FixedPlayerMovement>();
            if (bc != null)
            {
                if(bc.booksNum > 0)
                {
                    bc.booksNum -= 1;
                }
                this.gameObject.SetActive(false);
            }
            
        }
    }

    void AfterAnimation()
    {
        Destroy(gameObject);
    }
}
