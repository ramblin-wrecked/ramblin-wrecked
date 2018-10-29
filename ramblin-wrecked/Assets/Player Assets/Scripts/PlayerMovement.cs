using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour {

    //jumping Variables
    public float walkJumpVel = 14f;
    public float runJumpVel = 18f;
    public float fallMultiplier = 8f;
    public float lowJumpMultiplier = 8f;
    public float bonusGravityMult = 2.5f;
    public Vector3 bonusGravity;
    public float distToGround = 1;


    //moving Variables
    public float walkSpeed = 2f;
    public float runAccel = 4f;
    public float friction = 0.75f;
    public float xVel;
    public float zVel;
    public float airAccel = 2f;
    public float maxAirVel;
    public Vector3 moveVelocity;

    //Dizzy Variables
    public bool isDizzy;
    public float defaultDizzyDuration = 210f;
    public float dizzyDuration = 0f;


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
        //isGrounded = false;
    }

    void Update()
    {
        DizzyHandler();
        Vector3.Normalize(dirVector);
        Point(dirVector);
        Move(dirVector, Input.GetButton("Fire3"));
        jump("Jump", Input.GetButton("Fire3"));
    }

    void DizzyHandler()
    {
        if(isDizzy)
        {
            dirVector.Set(-1f*Input.GetAxisRaw("Horizontal"), 0f, -1f*Input.GetAxisRaw("Vertical"));
            dizzyDuration -= 1f;
            if (dizzyDuration <= 0f) {
                isDizzy = false;
                dizzyDuration = 210f;
            }
        } else {
            dirVector.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
    }

    //Moves the player
    void Move (Vector3 dirVector, bool running)
    {
        rigidbody.position += moveVelocity;
        if (IsGrounded())
        {
            if (running)
            {
                xVel += dirVector.x * runAccel * Time.deltaTime;
                zVel += dirVector.z * runAccel * Time.deltaTime;
                moveVelocity.Set(xVel, 0f, zVel);
            }
            else
            {
                moveVelocity = dirVector * walkSpeed * Time.deltaTime;
            }
            if (moveVelocity.magnitude < 2f) maxAirVel = 2f;
            else maxAirVel = moveVelocity.magnitude;

        } else {
            moveVelocity += dirVector * airAccel * Time.deltaTime;
            moveVelocity = Vector3.ClampMagnitude(moveVelocity, maxAirVel);
        }
        // regulates friction
        if (xVel != 0f)
        {
            if (xVel < 0.025f && xVel > -0.025f) xVel = 0f;
            else xVel *= friction;
        }
        if (zVel != 0f)
        {
            if (zVel < 0.025f && zVel > -0.025f) zVel = 0f;
            else zVel *= friction;
        }
    }

    //Points the player
    void Point(Vector3 dirVector)
    {
        if(dirVector.sqrMagnitude > 0)
        {
            if(IsGrounded()) {
                //dirQuaternion.SetLookRotation(dirVector);
                transform.LookAt(transform.position + dirVector);
            }
        }
    }

    //Makes the player jump
    void jump(string input, bool running)
    {
        if (IsGrounded()) {
            if (Input.GetButtonDown(input)) {
                if (running) rigidbody.velocity += Vector3.up * runJumpVel;
                else rigidbody.velocity += Vector3.up * walkJumpVel;
            }
            else rigidbody.velocity.Set(rigidbody.velocity.x, 0f, rigidbody.velocity.y);
        }
        else {
            if (rigidbody.velocity.y < 0) {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rigidbody.velocity.y > 0 && !Input.GetButton(input)) {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            rigidbody.velocity += Vector3.up * Physics.gravity.y * bonusGravityMult * Time.deltaTime;
        }
    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


    void OnTriggerEnter(Collider c) {
        if (c.tag == "Cup")
        {
            isDizzy = true;
        }
    }
 }
