using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;

    void Start (){
        target = GameObject.Find("Player").transform;
    }

    void Update ()
     {
         range = Vector2.Distance(transform.position, target.position);
 
         if (range > minDistance)
         {
             Debug.Log(range);
 
             transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
         }

         Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         
     }

}
