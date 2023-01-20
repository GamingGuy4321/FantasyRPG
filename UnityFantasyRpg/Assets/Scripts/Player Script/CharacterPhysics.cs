using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
 
public class CharacterPhysics : MonoBehaviour
{
    public float walkSpeed = 4;
    public float runSpeed = 9;

    public float noSpeed = 0;
    
    public float gravity = -20f;
    public float jumpSpeed = 15;
    public bool m_isMoving = false;

    Vector3 moveVelocity;

    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("CharacterController is null. Please assign this.");
        }
    }
     void Update () {
        var verticalInput = Input.GetAxis("Vertical");


        //Debug.Log($"Character Controller isGrounded = {controller.isGrounded}");
        if (controller.isGrounded)
        {
            //Pull this out of the Grounded check if you want walking animation to be able to play while in the air
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                m_isMoving = true;
            }
            else
            {
                m_isMoving = false;
            }

            moveVelocity = transform.forward * walkSpeed * verticalInput;

            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed;
            }

        }
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);

        if (m_isMoving)
        {
            // Left Shift input detected
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetBool("isRunning", true);
                walkSpeed = runSpeed;
            }
            else
            {
                walkSpeed = 4;
                GetComponent<Animator>().SetBool("isRunning", false);
            }
        }
    }
         
}
