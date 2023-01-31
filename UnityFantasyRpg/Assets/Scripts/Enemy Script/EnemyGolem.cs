using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolem : MonoBehaviour
{
    public Rigidbody rigid;
    public Transform Player;
    public GameObject Golem;

    CharacterController controller;
    Animator animator;

   
    private float nextFireTimeSlam;
    public float slamCoolDownTime;
    public GameObject slamEnd;
    public float slamTimer;

    private float nextFireTimeSwipe;
    public float swipeCoolDownTime;
    public Collider swipeCollider;
    public float swipeTimer;


    
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

        if (swipeTimer <= 0){
                swipeCollider.enabled = false; 
                swipeTimer = 0.6f;
        }
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (Time.time > nextFireTimeSwipe)){
            animator.SetTrigger("isSwipeAttack");
            nextFireTimeSwipe = Time.time + swipeCoolDownTime;
        }

        if (Time.time > nextFireTimeSlam){
            rigid.AddForce(0, 20,0);
            animator.SetTrigger("isSlamAttack");
            nextFireTimeSlam = Time.time + slamCoolDownTime;
        }
    }

    void Swipe(){
            swipeCollider.enabled = true; 
            swipeTimer = 2.0f;
         }
}
