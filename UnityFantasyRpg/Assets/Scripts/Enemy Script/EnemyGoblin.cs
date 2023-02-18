using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Transform player;
    public GameObject Goblin;

    private float nextFireTimeLightAttack;
    private float nextFireTimeLightAttack2;
    private float nextFireTimeHeavyAttack;
    public float lightAttackCoolDownTime;
    public float lightAttack2CoolDownTime;
    public float heavyAttackCoolDownTime;
    public float lightAttackTimer;
    public float lightAttack2Timer;
    public float heavyAttackTimer;

    public bool isLightAttack;
    public bool isLightAttack2;
    public bool isHeavyAttack;

    public Collider leftLightDaggerCollider;
    public Collider rightLightDaggerCollider;
    public Collider heavyDaggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        controller = player.gameObject.GetComponent<CharacterController>();
        animator = Goblin.gameObject.GetComponent<Animator>();
        heavyDaggerCollider.enabled = false;
        leftLightDaggerCollider.enabled = false;
        rightLightDaggerCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLightAttack){
            leftLightDaggerCollider.enabled = true; 
        }

        if(isLightAttack2){
            rightLightDaggerCollider.enabled = true; 
        }

        if(isHeavyAttack){
            heavyDaggerCollider.enabled = true;
        }

        if(leftLightDaggerCollider.enabled){
            lightAttackTimer -= Time.deltaTime;
            if (lightAttackTimer <= 0){
                leftLightDaggerCollider.enabled = false; 
                lightAttackTimer = 1.0f;
                isLightAttack = false;
            }
        }

        if(rightLightDaggerCollider.enabled){
            lightAttack2Timer -= Time.deltaTime;
            if (lightAttack2Timer <= 0){
                rightLightDaggerCollider.enabled = false; 
                lightAttack2Timer = 1.0f;
                isLightAttack2 = false;
            }
        }

        if(heavyDaggerCollider.enabled){
            heavyAttackTimer -= Time.deltaTime;
            if(heavyAttackTimer <= 0){
                heavyDaggerCollider.enabled = false; 
                heavyAttackTimer = 1.0f;
                isHeavyAttack = false;
            }
        }

        MeleeAttack();
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 4);

        if (rand == 1 && (controller.isGrounded) && (Time.time > nextFireTimeLightAttack)){
            animator.SetTrigger("isLightAttack");
            nextFireTimeLightAttack = Time.time + lightAttackCoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTimeLightAttack2)){
            animator.SetTrigger("isLightAttack2");
            nextFireTimeLightAttack2 = Time.time + lightAttack2CoolDownTime;
        }

        if (rand == 3 && (controller.isGrounded) && (Time.time > nextFireTimeHeavyAttack)){
            animator.SetTrigger("isHeavyAttack");
            nextFireTimeHeavyAttack = Time.time + heavyAttackCoolDownTime;
        }
    }

    void LightAttack(){
    }

    void LightAttack2(){
    }

    void HeavyAttack(){
    }
}
