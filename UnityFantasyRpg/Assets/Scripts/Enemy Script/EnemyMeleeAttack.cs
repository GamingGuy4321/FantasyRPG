using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private float nextFireTimeLightAttack;
    private float nextFireTimeHeavyAttack;
    public float lightAttackCoolDownTime;
    public float heavyAttackCoolDownTime;
    public Transform Player;
    public GameObject meleeEnemy;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = Player.gameObject.GetComponent<CharacterController>();
        animator = meleeEnemy.gameObject.GetComponent<Animator>();
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
            nextFireTimeLightAttack = Time.time + lightAttackCoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTimeHeavyAttack)){
            animator.SetTrigger("isHeavyAttack");
            nextFireTimeHeavyAttack = Time.time + heavyAttackCoolDownTime;
        }
    }
}
