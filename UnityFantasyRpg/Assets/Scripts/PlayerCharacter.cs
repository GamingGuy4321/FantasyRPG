using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public CharacterController _controller;
    public Animator m_animator;
    Rigidbody m_rigidbody;
    public float _speed = 10;
    public float _runSpeed = 20;
    public float _rotationSpeed = 180;
     public bool m_isMoving = false;

 
    private Vector3 rotation;
 
    void Start(){
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        _controller.Move(move * _speed);

        if(Input.GetAxisRaw("Vertical")!= 0){
            m_animator.SetBool("isWalking", true);
            m_isMoving = true;
        }else{
            m_animator.SetBool("isIdle", true);
            m_isMoving = false;
        }

        if (m_isMoving) {
                // Left Shift input detected
                if (Input.GetKey(KeyCode.LeftShift)) {
                    m_animator.SetBool("isRunning", true);
                    _speed = _runSpeed;
                }else{
                    _speed = _speed;
                    m_animator.SetBool("isWalking", true);
                }
        }
        
    }
}
