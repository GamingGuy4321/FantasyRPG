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
    public bool isSwiping;

    // Start is called before the first frame update
    void Start()
    {
        controller = Player.gameObject.GetComponent<CharacterController>();
        animator = Golem.gameObject.GetComponent<Animator>();
        swipeCollider.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(swipeCollider.enabled){
            swipeTimer -= Time.deltaTime;
            if (swipeTimer <= 0){
            swipeCollider.enabled = false; 
            swipeTimer = 1.0f;
            isSwiping = false;
           }
        }

        MeleeAttack();
    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        if ((rand == 1) && (Time.time > nextFireTimeSwipe)){
            animator.SetTrigger("isSwipeAttack");
            if(isSwiping){
                swipeCollider.enabled = true; 
            }
            nextFireTimeSwipe = Time.time + swipeCoolDownTime;
        }

        if ((rand == 2) && (Time.time > nextFireTimeSlam)){
            animator.SetTrigger("isSlamAttack");
            nextFireTimeSlam = Time.time + slamCoolDownTime;
        }
    }

    void SwipeEvent(){

    }

    void SlamLand(){

    }
}
