using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class FixedPlayerMovement : MonoBehaviour
{

    //jumping Variables
    float walkJumpVel = 14f;
    float runJumpVel = 18f;
    float fallMultiplier = 8f;
    float lowJumpMultiplier = 8f;
    float bonusGravityMult = 2.5f;
    float airDrag = 0.95f;
    Vector3 bonusGravity;
    float distToGround = 1;
    public bool canDoubleJump;


    //moving Variables
    float walkSpeed = 7f;
    float runAccel = 4f;
    float friction = 0.75f;
    float xVel;
    float zVel;
    float airAccel = 1f;
    float maxAirVel;
    public Vector3 moveVelocity;

    //Used to scale Movement dynamics to avatar's size
    public float scaleBy = 1f;

    //Used for turning and other such drab.
    Quaternion dirQuaternion;
    Vector3 dirVector;
    Rigidbody rigidbody;
    CharacterController charCtrl;
    Collider charCollider;
    Animator anim;
    bool isRunning;

    public bool isDizzy = false;
    public int maxDizzyDuration = 210;
    public int curDizzyDuration = 0;



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        charCtrl = GetComponent<CharacterController>();
        charCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        transform.localScale = new Vector3(scaleBy, scaleBy, scaleBy);
    }

    void FixedUpdate()
    {
        if (!TimeKeeper.isPaused)
        {
            DizzyHandler();
            Vector3.Normalize(dirVector);
            Point(dirVector);
            Move(dirVector, Input.GetButton("Fire3"));
            jump("Jump", Input.GetButton("Fire3"));
        }
    }

    void DizzyHandler()
    {
        if (isDizzy)
        {
            dirVector.Set(-1f * Input.GetAxisRaw("Horizontal"), 0f, -1f * Input.GetAxisRaw("Vertical"));
            curDizzyDuration -= 1;
            if (curDizzyDuration <= 0)
            {
                curDizzyDuration = maxDizzyDuration;
                isDizzy = false;
            }
        }
        else
        {
            dirVector.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
    }

    //Moves the player
    void Move(Vector3 dirVector, bool running)
    {
        rigidbody.position += moveVelocity;
        if (IsGrounded())
        {
            if (running)
            {

                xVel += dirVector.x * scaleBy * runAccel * TimeKeeper.GetDeltaTime();
                zVel += dirVector.z * scaleBy * runAccel * TimeKeeper.GetDeltaTime();
                moveVelocity.Set(xVel, 0f, zVel);
            }
            else
            {
                moveVelocity = dirVector * scaleBy * walkSpeed * TimeKeeper.GetDeltaTime();
            }
            if (moveVelocity.magnitude < scaleBy * 2f) maxAirVel = scaleBy * 2f;
            else
            {
                anim.SetTrigger("IsWalking");
                maxAirVel = moveVelocity.magnitude;
            }

        }
        else
        {
            moveVelocity += dirVector * scaleBy * airAccel * TimeKeeper.GetDeltaTime();
            moveVelocity *= airDrag;
            moveVelocity = Vector3.ClampMagnitude(moveVelocity, maxAirVel);
        }
        // regulates running friction
        if (xVel != 0f)
        {
            if (xVel < 0.025f && xVel > -0.025f) xVel = 0f;
            else
            {
                anim.SetTrigger("IsRunning");
                xVel *= friction;
            }
        }
        if (zVel != 0f)
        {
            if (zVel < 0.025f && zVel > -0.025f) zVel = 0f;
            else
            {
                anim.SetTrigger("IsRunning");
                zVel *= friction;
            }
        }
    }

    //Points the player
    void Point(Vector3 dirVector)
    {
        if (dirVector.sqrMagnitude > 0)
        {
            if (IsGrounded())
            {
                transform.LookAt(transform.position + dirVector);
            }
        }
    }

    //Makes the player jump
    void jump(string input, bool running)
    {
        if (IsGrounded())
        {
            if (Input.GetButtonDown(input))
            {
                if (running) rigidbody.velocity = new Vector3(rigidbody.velocity.x, scaleBy * runJumpVel, rigidbody.velocity.z);
                else rigidbody.velocity = new Vector3(rigidbody.velocity.x, scaleBy * walkJumpVel, rigidbody.velocity.z);
                anim.SetTrigger("IsJumping");
            }
            else rigidbody.velocity.Set(rigidbody.velocity.x, 0f, rigidbody.velocity.y);
            canDoubleJump = true;
        }
        else
        {
            if(!Input.GetButton(input)) {
                if (canDoubleJump && Input.GetButtonDown(input))
                {
                    anim.SetTrigger("IsDoubleJumping");
                    if (running) rigidbody.velocity = new Vector3(rigidbody.velocity.x, 1.25f * scaleBy * runJumpVel, rigidbody.velocity.z);
                    else rigidbody.velocity = new Vector3(rigidbody.velocity.x, 1.25f * scaleBy * walkJumpVel, rigidbody.velocity.z);

                    canDoubleJump = false;
                }
            }
            if (rigidbody.velocity.y < 0)
            {
                rigidbody.velocity += Vector3.up * scaleBy * Physics.gravity.y * (fallMultiplier - 1) * TimeKeeper.GetDeltaTime();
            }
            else if (rigidbody.velocity.y > 0 && !Input.GetButton(input))
            {
                rigidbody.velocity += Vector3.up * scaleBy * Physics.gravity.y * (lowJumpMultiplier - 1) * TimeKeeper.GetDeltaTime();
            }
            rigidbody.velocity += Vector3.up * scaleBy * Physics.gravity.y * bonusGravityMult * TimeKeeper.GetDeltaTime();
        }
    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround * scaleBy + 0.1f);
        anim.SetTrigger("IsGrounded");
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Cup")
        {
            isDizzy = true;
        }
    }
}
