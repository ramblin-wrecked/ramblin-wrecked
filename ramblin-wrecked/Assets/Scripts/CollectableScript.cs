using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Animator), typeof(AudioSource))]
public class CollectableScript : MonoBehaviour {

    Animator anim;
    AudioSource sfx;
    Transform trans;

    public int creditValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
        trans = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player") 
        {
            GameState.credits += creditValue;
            anim.SetTrigger("Touches Player");
            sfx.Play();
        }
    }

    void AfterAnimation()
    {
        Destroy(gameObject);
    }
}
