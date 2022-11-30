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
    private Vector3 rotation;
    float timer;
    public GameObject iceSlam;
    public GameObject knifeHail;
    public GameObject projectilePrefab;
    public Transform projectileFirePoint;
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public int maxMana = 250;
    public int currentMana;
    public Manabar manabar;
    public int maxHealthPotion = 99;
    public int currentHealthPotion;
    public int maxManaPotion = 99;
    public int currentManaPotion;
 
    void Start(){
        m_animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
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
        
        if (Input.GetKeyDown(KeyCode.Space)){
            m_animator.SetTrigger("isJumping");
            print("jumped");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if(currentHealthPotion >= 1){
                    currentHealth += 50;
                    print("used health potion");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            if(currentManaPotion >= 1){
                currentMana += 50;
                print("used mana potion");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)){
            if (currentMana >= 20){
            Instantiate(projectilePrefab, projectileFirePoint.position, projectileFirePoint.rotation);
            m_animator.SetTrigger("isIceBolt");
            takeMana(20);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)){
            if (currentMana >= 50){
            iceSlam.SetActive(true);
            m_animator.SetTrigger("isIceslam");
            takeMana(50);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)){
            if (currentMana >= 35){
            knifeHail.SetActive(true);
            m_animator.SetTrigger("isKnifeHail");
            takeMana(35);
            }
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

        void takeMana(int spellUse){
            currentMana -= spellUse;
            manabar.SetMana(currentMana);
        }
        
    }
}
