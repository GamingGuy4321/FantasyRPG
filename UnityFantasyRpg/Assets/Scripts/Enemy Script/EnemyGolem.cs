using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGolem : MonoBehaviour
{
    public Rigidbody rigid;
    public NavMeshAgent navMesh;

    Transform player;
    public GameObject Golem;

    CharacterController controller;
    Animator animator;
   
    private float nextFireTimeSlam;
    public float slamCoolDownTime;
    public GameObject slamEnd;

    private float nextFireTimeSwipe;
    public float swipeCoolDownTime;
    public Collider swipeCollider;
    public float swipeTimer;
    public bool isSwiping;

    public bool isSlaming;
    public bool isJumping;
    public bool hasSavePosition = false;

    public float jumpSpeed = 15;

    public float jumpTimer;
    public float slamEndTimer;
    Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        controller = player.gameObject.GetComponent<CharacterController>();
        animator = Golem.gameObject.GetComponent<Animator>();
        swipeCollider.enabled = false; 
        slamEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update(){   

        if(isSwiping){
            swipeCollider.enabled = true; 
        }

        if(isSlaming){
            slamEnd.SetActive(true);
            slamEndTimer -= Time.deltaTime;
            if (slamEndTimer <= 0){
                slamEnd.SetActive(false);
                slamEndTimer = 1.0f;
                isSlaming = false;
            }
        }

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

    void FixedUpdate() {
        if(isJumping){
            if(hasSavePosition == false){
                tempPosition = transform.position;
                hasSavePosition = true;
            }
            
            navMesh.enabled = false;
            jumpTimer -= Time.deltaTime;

            if(jumpTimer <=0){
                isJumping = false;
                jumpTimer = 2.0f;
                hasSavePosition = false;
                if (!navMesh.isOnNavMesh){
                    Vector3 warpPosition = tempPosition; //Set to position you want to warp to
                    navMesh.transform.position = warpPosition;
                    navMesh.enabled = false;
                    navMesh.enabled = true;
                }else{
                    navMesh.enabled = true;
                }
            }
            Debug.Log("Jumping");
            rigid.AddForce(0, jumpSpeed,0,ForceMode.Impulse);
        }

    }

    void MeleeAttack(){
        int rand = Random.Range(1, 3);

        // if ((rand == 1) && (Time.time > nextFireTimeSwipe)){
        //     animator.SetTrigger("isSwipeAttack");
        //     nextFireTimeSwipe = Time.time + swipeCoolDownTime;
        // }

        if ((rand == 2) && (Time.time > nextFireTimeSlam)){
            animator.SetTrigger("isSlamAttack");
            nextFireTimeSlam = Time.time + slamCoolDownTime;
        }
    }

    void SwipeEvent(){

    }

    void SlamLand(){

    }

    void Jump(){
    }
}
