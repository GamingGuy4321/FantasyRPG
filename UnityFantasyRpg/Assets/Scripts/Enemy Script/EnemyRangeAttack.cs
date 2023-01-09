using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject aoeCirclePrefab;
    public GameObject aoePrefab;
    public GameObject projectilePrefab;
    public Transform projectileFirePoint;
    private float nextFireTime;
    public float lightningboltcoolDownTime;
    public float lightningstrikecoolDownTime;
    public Transform Player;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = Player.gameObject.GetComponent<CharacterController>();
        RangeAttack();
    }

    // Update is called once per frame
    void Update()
    {
        RangeAttack();
    }

    void RangeAttack(){
        int rand = Random.Range(1, 3);

        if (rand == 1 && (Time.time > nextFireTime)){
            Instantiate(projectilePrefab, projectileFirePoint.position, projectileFirePoint.rotation);
            nextFireTime = Time.time + lightningboltcoolDownTime;
        }

        if (rand == 2 && (controller.isGrounded) && (Time.time > nextFireTime)){
            Instantiate(aoeCirclePrefab, Player.position, Quaternion.Euler(-90f,0f,0f));
            Instantiate(aoePrefab, Player.position, Quaternion.Euler(0f,0f,0f));
            nextFireTime = Time.time + lightningstrikecoolDownTime;
        }
    }
}
