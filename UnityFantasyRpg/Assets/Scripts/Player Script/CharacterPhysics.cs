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

    public float dodgeMove = 1f;
    private float dodgeSpeed = 5f;

    public bool isDodgingLeft;
    public bool isDodgingRight;

    private float dodgeTimer = 2.0f;

    Vector3 dodge;

    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("CharacterController is null. Please assign this.");
        }
    }
     void Update () 
     {
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

        if (Input.GetKeyDown(KeyCode.A))
            {
                GetComponent<Animator>().SetTrigger("isDodgingLeft");
                
            }

        if (isDodgingLeft){
            dodgeTimer -= Time.deltaTime;

            if (dodgeTimer<= 0){
                isDodgingLeft = false;
                dodgeTimer = 2.0f;
            }

            controller.Move(new Vector3(-dodgeMove, 0, 0)*Time.deltaTime*dodgeSpeed);
        }

        if (Input.GetKeyDown(KeyCode.D))
            {
                GetComponent<Animator>().SetTrigger("isDodgingRight");
            }

        if (isDodgingRight){
            dodgeTimer -= Time.deltaTime;

            if (dodgeTimer<= 0){
                isDodgingRight = false;
                dodgeTimer = 2.0f;
            }

            controller.Move(new Vector3(dodgeMove, 0, 0)*Time.deltaTime*dodgeSpeed);
        }

    }

         

         void DodgeEvent(){
            isDodgingLeft = true;
         }

          void DodgeEventRight(){
            isDodgingRight = true;
          }
}
