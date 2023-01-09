using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public GameObject aoePrefab;
    public GameObject projectilePrefab;
    public Transform projectileFirePoint;
    private float nextFireTime;
    public float lightningboltcoolDownTime;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        RangeAttack();
    }

    // Update is called once per frame
    void Update()
    {
        RangeAttack();
    }

    void RangeAttack(){
        int rand = Random.Range(1, 2);

        if (rand == 1 && (Time.time > nextFireTime)){
            Instantiate(projectilePrefab, projectileFirePoint.position, projectileFirePoint.rotation);
            nextFireTime = Time.time + lightningboltcoolDownTime;
        }

        if (rand == 2){
            Instantiate(aoePrefab, Player.position, Quaternion.identity);
        }
    }
}
