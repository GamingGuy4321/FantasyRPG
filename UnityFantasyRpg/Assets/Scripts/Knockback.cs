using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour{

    [SerializeField] private float knockbackStrength;
    
    private void OnTriggerEnter(Collider collision) {

        Rigidbody rb = collision.GetComponent<Collider>().GetComponent<Rigidbody>();

        if(rb != null){
                Vector3 direction = collision.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }
}
