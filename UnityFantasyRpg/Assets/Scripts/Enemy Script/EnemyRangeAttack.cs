using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject aoeCirclePrefab;
    public GameObject aoePrefab;
    public GameObject projectilePrefab;
    public Transform projectileFirePoint;
    private float nextFireTimeSingleTarget;
    private float nextFireTimeAOE;
    public float singleTargetCoolDownTime;
    public float AOEcoolDownTime;
    Transform player;
    public GameObject rangeEnemy;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        controller = player.gameObject.GetComponent<CharacterController>();
        animator = rangeEnemy.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        RangeAttack();
    }

    void RangeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (Time.time > nextFireTimeSingleTarget)){
            animator.SetTrigger("isSingleAttack");
            Instantiate(projectilePrefab, projectileFirePoint.position, projectileFirePoint.rotation);
            nextFireTimeSingleTarget = Time.time + singleTargetCoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTimeAOE)){
            animator.SetTrigger("isAOEAttack");
            Instantiate(aoeCirclePrefab, player.position, Quaternion.Euler(-90f,0f,0f));   
            Instantiate(aoePrefab, player.position, Quaternion.Euler(0f,0f,0f));
            nextFireTimeAOE = Time.time + AOEcoolDownTime;
        }
    }
}
