using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
    public Transform Player;
    public GameObject Goblin;
    CharacterController controller;
    Animator animator;

    private float nextFireTimeLightAttack;
    private float nextFireTimeHeavyAttack;
    public float lightAttackCoolDownTime;
    public float heavyAttackCoolDownTime;

    public Collider leftLightDagger;
    public Collider rightLightDagger;
    public Collider heavyDagger;

    // Start is called before the first frame update
    void Start()
    {
        controller = Player.gameObject.GetComponent<CharacterController>();
        animator = Goblin.gameObject.GetComponent<Animator>();
        heavyDagger.enabled = false;
        leftLightDagger.enabled = false;
        rightLightDagger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MeleeAttack();
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (Time.time > nextFireTimeLightAttack)){
            animator.SetTrigger("isLightAttack");
            animator.SetTrigger("isLightAttack2");
            nextFireTimeLightAttack = Time.time + lightAttackCoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTimeHeavyAttack)){
            animator.SetTrigger("isHeavyAttack");
            nextFireTimeHeavyAttack = Time.time + heavyAttackCoolDownTime;
        }
    }

    void LightAttack(){

    }

    void LightAttack2(){

    }

    void HeavyAttack(){
        heavyDagger.enabled = true;
    }
}
