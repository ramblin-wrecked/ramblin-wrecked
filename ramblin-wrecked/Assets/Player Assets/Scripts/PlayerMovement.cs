using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float smallJump = 6f;
    public float bigJump = 12f;
    public float walkSpeed = 15f;
    public float maxSpeed = 30f;
    public float friction = 0.90f;
    public float velocity = 0f;
    public float acceleration = 1f;
    Quaternion dirQuaternion;
    Vector3 dirVector;
    Rigidbody rigidbody;
    CharacterController charCtrl;
    bool isRunning;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        charCtrl = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        dirVector.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Point(dirVector);
        Move(dirVector);
        rigidbody.AddForce(Physics.gravity * rigidbody.mass);
        jump(Input.GetButtonDown("Jump"));
    }

    //Moves the player
    void Move (Vector3 dirVector)
    {
        rigidbody.position += transform.forward * Time.deltaTime * velocity;
        if (dirVector.magnitude > 0)
        {
            if (velocity < maxSpeed) velocity += acceleration;
            else velocity = maxSpeed;
        } else {
            if (velocity > 0.5f) velocity *= friction;
            else velocity = 0f;
        }
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
    void jump(bool jump)
    {
        if(jump)
        {
            rigidbody.AddForce(Vector3.up * bigJump);
        }
    }
}
