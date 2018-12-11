using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(AudioSource), typeof(Animator))]
public class HWCollectable : MonoBehaviour {
    Animator anim;
    AudioSource sfx;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
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
                    bc.bookWt += .2f;
                }

                anim.SetTrigger("TouchesPlayer");
                sfx.Play();
            }
            
        }
    }

    void AfterAnimation()
    {
        Destroy(gameObject);
    }
}
