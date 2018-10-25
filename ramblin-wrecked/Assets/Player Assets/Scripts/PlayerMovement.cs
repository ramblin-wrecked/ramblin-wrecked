using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour {

    //Verticle Movment Variables
    public float jumpVel = 12f;
    public float fallMultiplier = 2.5f;
    public bool isGrounded;

    //Horizontal Movement Variables
    public float walkSpeed = 15f;
    public float maxSpeed = 30f;
    public float friction = 0.90f;
    public float velocity = 0f;


    Quaternion dirQuaternion;
    Vector3 dirVector;
    Rigidbody rigidbody;
    CharacterController charCtrl;
    Collider charCollider;
    bool isRunning;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        charCtrl = GetComponent<CharacterController>();
        charCollider = GetComponent<CapsuleCollider>();
        isGrounded = false;
    }

    void Update()
    {
        dirVector.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3.Normalize(dirVector);
        Point(dirVector);
        Move(dirVector, Input.GetButton("Fire3"));
        jump("Jump");
    }
    void FixedUpdate()
    {

    }

    //Moves the player
    void Move (Vector3 dirVector, bool running)
    {
        bool shouldMove = dirVector.magnitude > 0f;
        if (isGrounded){
            rigidbody.position += transform.forward * Time.deltaTime * velocity;

        } else {
            rigidbody.position += dirVector * Time.deltaTime * velocity;
        }

        if (shouldMove) {
            if (running) velocity = maxSpeed;
            else velocity = walkSpeed;
        }
        if (velocity > 0.5f) {
            velocity *= friction;
        }
        else velocity = 0f;
    }

    //Points the player
    void Point(Vector3 dirVector)
    {
        if(dirVector.magnitude > 0)
        {
            dirQuaternion.SetLookRotation(dirVector);
            rigidbody.MoveRotation(dirQuaternion);
        }
    }

    //Makes the player jump
    void jump(string input)
    {
        if(Input.GetButtonDown(input))
        {
            if (isGrounded)
            {
                rigidbody.AddForce(Vector3.up * jumpVel, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        if(rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    //Physics Callback
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            isGrounded = true;
        }
    }

    //Physics Callback
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
