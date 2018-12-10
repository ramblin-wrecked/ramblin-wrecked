using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent), typeof(Animator))]
public class BookAI : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent navMesh;
    Animator anim;

    GameObject target;
    //public GameObject target;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (anim == null)
        {
            Debug.Log("animator not found");
        }
        if (navMesh == null)
        {
            Debug.Log("Nav Mesh Agent not found");
        }
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            Debug.Log("Player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("throw", navMesh.velocity.magnitude / navMesh.speed);

        Vector3 mag = (target.transform.position - this.transform.position);
        float dist = mag.magnitude;
        float lookAhead = dist / navMesh.speed;
        //VelControl getvel = gameObject.GetComponent("VelControl") as VelControl;
        Vector3 futureTarget = target.transform.position;// + target.GetComponent<VelControl>().velocity;
        navMesh.SetDestination(futureTarget);
        if (navMesh.remainingDistance <= .7 && navMesh.pathPending != true) //collided!
        {
            //play sound
            //reverse direction of controls
            //stop throwing


        }
    }
}
