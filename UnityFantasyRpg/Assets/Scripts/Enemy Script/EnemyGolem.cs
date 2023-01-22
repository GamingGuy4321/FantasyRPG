using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolem : MonoBehaviour
{
    private float nextFireTimeSwipe;
    private float nextFireTimeSlam;
    public float swipeCoolDownTime;
    public float slamCoolDownTime;
    public Transform Player;
    public GameObject Golem;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = Player.gameObject.GetComponent<CharacterController>();
        animator = Golem.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MeleeAttack();
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (Time.time > nextFireTimeSwipe)){
            animator.SetTrigger("isSwipeAttack");
            nextFireTimeSwipe = Time.time + swipeCoolDownTime;
        }

        if (Time.time > nextFireTimeSlam){
            animator.SetTrigger("isSlamAttack");
            nextFireTimeSlam = Time.time + slamCoolDownTime;
        }
    }
}
