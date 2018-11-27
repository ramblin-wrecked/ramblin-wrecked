using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Animator))]
public class CollectableScript : MonoBehaviour {

    Animator anim;
    Transform trans;

    public int creditValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player") 
        {
            GameState.credits += creditValue;
            anim.SetTrigger("Touches Player");
        }
    }

    void AfterAnimation()
    {
        Destroy(gameObject);
    }
}
