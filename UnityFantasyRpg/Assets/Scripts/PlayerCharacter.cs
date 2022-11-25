using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public CharacterController _controller;
    public Animator m_animator;
    public float _speed = 4;
    public float _runSpeed = 9;
    public float _rotationSpeed = 90;
    public bool m_isMoving = false;
    private bool isMouseLeftDown = false;
    public GameObject iceSlam;
    public GameObject laser;
    float timer;
 
    private Vector3 rotation;
 
    void Start(){
        m_animator = GetComponent<Animator>();
    }

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);

        if (Input.GetMouseButtonDown(0)){
            Debug.Log("MousebuttonDown");
            if(!isMouseLeftDown ){
                timer=Time.time;
                isMouseLeftDown = true;
            }
        }

        if (Input.GetMouseButtonUp(0)){
            Debug.Log("MousebuttonUp");
            isMouseLeftDown = false;
            if(Time.time - timer < 0.25){
                Debug.Log("LightAttack.");
                m_animator.SetTrigger("isLightAttack");
            }else if(Time.time - timer > 0.5){
                Debug.Log("HeavyAttack.");
                m_animator.SetTrigger("isHeavyAttack");   
            }
        }

        if (Input.GetMouseButtonDown(1)){
            Debug.Log("Blocked");
            m_animator.SetBool("isBlocking", true);  
        }else{
            m_animator.SetBool("isBlocking", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            iceSlam.SetActive(true);
            m_animator.SetTrigger("isIceslam");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            laser.SetActive(true);
            m_animator.SetTrigger("isFiringmylaser");
        }


        if (Input.GetKeyDown(KeyCode.Space)){
            m_animator.SetTrigger("isJumping");
        }


        if(Input.GetAxisRaw("Vertical")!= 0){
            m_animator.SetBool("isWalking", true);
            m_isMoving = true;
        }else if (Input.GetAxisRaw("Vertical")== 0){
            m_isMoving = false;
            m_animator.SetBool("isWalking", false);
        }

        if(Input.GetAxisRaw("Horizontal") < 0){
            m_animator.SetBool("isTurningLeft", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0){
            m_animator.SetBool("isTurningRight", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0){
            m_animator.SetBool("isTurningRight", false);
            m_animator.SetBool("isTurningLeft", false);
        }
        
        if (m_isMoving) {
                // Left Shift input detected
                if (Input.GetKey(KeyCode.LeftShift)) {
                    m_animator.SetBool("isRunning", true);
                    _speed = _runSpeed;
                }else{
                    _speed = 4;
                    m_animator.SetBool("isRunning", false);
                }
        }
        
    }
}
