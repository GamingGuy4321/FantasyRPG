using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCharacter : MonoBehaviour
{

    public Animator m_animator;
    private bool isMouseLeftDown = false;
    
    float timer;
    public GameObject iceSlam;
    public GameObject iceSlamExplosion;
    public GameObject knifeHail;
    public GameObject projectilePrefab;
    public GameObject healAura;
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
    public float healthpotioncoolDownTime;
    public float manapotioncoolDownTime;
    public float iceboltcoolDownTime;
    public float iceslamcoolDownTime;
    public float knifehailcoolDownTime;
    private float nextFireTime;
    public GameObject sheathedShield;
    public GameObject equipedShield;
    public GameObject healthPotion;
    public GameObject manaPotion;
    public double enableTimer;
    private double internalTimer;
    public Collider swordCollider;
    public Collider swordCollider2;
    public float melee1Timer;
    public float melee2Timer;
    public Collider shieldCollider;
    public float shieldTimer;
   
 
    void Start(){
        m_animator = GetComponent<Animator>();
        swordCollider = swordCollider.GetComponent<BoxCollider>();
        swordCollider2 = swordCollider2.GetComponent<BoxCollider>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        swordCollider.enabled = false;
        swordCollider2.enabled = false;

    }

    public void Update()
    {

        if (GetComponent<CharacterPhysics>().m_isMoving)
        {
            m_animator.SetBool("isWalking", true);
        }
        else
        {
            m_animator.SetBool("isWalking", false);
        }


        if (internalTimer > 0){
            internalTimer -= Time.deltaTime;
            if(internalTimer < 0){
                equipedShield.SetActive(true);
            }
        }

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
                swordCollider.enabled = true;
                melee1Timer = 0.5f;
                Debug.Log("LightAttack.");
                m_animator.SetTrigger("isLightAttack");
            }else if(Time.time - timer > 0.5){
                swordCollider2.enabled = true;
                melee2Timer = 2.5f;
                Debug.Log("HeavyAttack.");
                m_animator.SetTrigger("isHeavyAttack");   
            }
        }

        if (Input.GetMouseButtonDown(1)){
            Debug.Log("Blocked");
            m_animator.SetBool("isBlocking", true);
            shieldCollider.enabled = true;  
            shieldTimer = 5.0f;
        }else{
            m_animator.SetBool("isBlocking", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)){
            m_animator.SetTrigger("isJumping");
            print("jumped");
        }

        //Left Shift input detected
            if (Input.GetKey(KeyCode.A))
            {
                m_animator.SetTrigger("isDodgingLeft");
            }
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            if (Time.time > nextFireTime){
                if(currentHealthPotion >= 1){
                    sheathedShield.SetActive(true);
                    equipedShield.SetActive(false);
                    healthPotion.SetActive(true);
                    m_animator.SetTrigger("isDrinkingPotion");
                    healAura.SetActive(true);
                    currentHealth += 50;
                    currentHealthPotion -= 1;
                    nextFireTime = Time.time + healthpotioncoolDownTime;
                    internalTimer = enableTimer;
                 }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            if (Time.time > nextFireTime){
                if(currentManaPotion >= 1){
                    sheathedShield.SetActive(true);
                    equipedShield.SetActive(false);
                    manaPotion.SetActive(true);
                    m_animator.SetTrigger("isDrinkingPotion");
                    currentMana += 50;
                    currentManaPotion -= 1;
                    nextFireTime = Time.time + manapotioncoolDownTime;
                    internalTimer = enableTimer;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)){
            if (Time.time > nextFireTime){
                if (currentMana >= 20){
                    
                    Instantiate(projectilePrefab, projectileFirePoint.position, projectileFirePoint.rotation);
                    m_animator.SetTrigger("isIceBolt");
                    takeMana(20);
                    nextFireTime = Time.time + iceboltcoolDownTime;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)){
            if (Time.time > nextFireTime){
                if (currentMana >= 50){
                    iceSlam.SetActive(true);
                    m_animator.SetTrigger("isIceslam");
                    takeMana(50);
                    nextFireTime = Time.time + iceslamcoolDownTime;
                    iceSlamExplosion.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)){
            if (Time.time > nextFireTime){
                if (currentMana >= 35){
                    knifeHail.SetActive(true);
                    m_animator.SetTrigger("isKnifeHail");
                    takeMana(35);
                    nextFireTime = Time.time + knifehailcoolDownTime;
                }
            }
        }      

        if(swordCollider.enabled){
            melee1Timer -= Time.deltaTime;
            if (melee1Timer <= 0){
                swordCollider.enabled = false;
            }
        } 

        if(swordCollider2.enabled){
            melee2Timer -= Time.deltaTime;
            if (melee2Timer <= 0){
                swordCollider2.enabled = false;
            }
        }

        if(shieldCollider.enabled){
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0){
                shieldCollider.enabled = false;
            }
        }

    }

        void takeMana(int spellUse){
            currentMana -= spellUse;
            manabar.SetMana(currentMana);
        }

        void OnTriggerEnter(Collider other) {

            if (other.gameObject.tag == "LightningBolt" && other.gameObject.tag != "Shield"){
                print("Player was hit by Lightning Bolt!");
                currentHealth -= 30;
            }

            if (other.gameObject.tag == "GolemSlam" ){
                print("That Looked like it hurt!");
                currentHealth -= 250;
            }
         }

         
}
