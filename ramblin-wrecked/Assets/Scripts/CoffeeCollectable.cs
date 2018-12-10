using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Animator), typeof(AudioSource))]
public class CoffeeCollectable : MonoBehaviour
{

    Animator anim;
    AudioSource sfx;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            FixedPlayerMovement bc = c.attachedRigidbody.gameObject.GetComponent<FixedPlayerMovement>();
            if (bc != null)
            {
                bc.hasCoffee = true;
                
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