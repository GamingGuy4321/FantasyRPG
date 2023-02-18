using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    
    CharacterController controller;
    Animator animator;
    Transform player;
    public GameObject meleeEnemy;

    private float nextFireTimeLightAttack;
    private float nextFireTimeHeavyAttack;
    public float lightAttackCoolDownTime;
    public float heavyAttackCoolDownTime;
    public float lightAttackTimer;
    public float heavyAttackTimer;

    public bool isLightAttack;
    public bool isHeavyAttack;
    public Collider lightCollider;
    public Collider heavyCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        controller = player.gameObject.GetComponent<CharacterController>();
        animator = meleeEnemy.gameObject.GetComponent<Animator>();
        lightCollider.enabled = false;
        heavyCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLightAttack){
            lightCollider.enabled = true;
        }

        if(lightCollider.enabled){
            lightAttackTimer -= Time.deltaTime;
            if (lightAttackTimer <= 0){
                lightCollider.enabled = false; 
                lightAttackTimer = 2.0f;
                isLightAttack = false;
            }
        }

        if(isHeavyAttack){
            heavyCollider.enabled = true;
        }

        if(heavyCollider.enabled){
            heavyAttackTimer -= Time.deltaTime;
            if (heavyAttackTimer <= 0){
                heavyCollider.enabled = false; 
                heavyAttackTimer = 3.5f;
                isHeavyAttack = false;
            } 
        }

        MeleeAttack();
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (controller.isGrounded) && (Time.time > nextFireTimeLightAttack)){
            animator.SetTrigger("isLightAttack");
            nextFireTimeLightAttack = Time.time + lightAttackCoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTimeHeavyAttack)){
            animator.SetTrigger("isHeavyAttack");
            nextFireTimeHeavyAttack = Time.time + heavyAttackCoolDownTime;
        }
    }

    void LightAttack(){
    }
    void HeavyAttack(){
    }
}
