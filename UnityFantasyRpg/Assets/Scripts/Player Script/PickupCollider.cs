using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollider : MonoBehaviour
{

   public PlayerCharacter player; 

   void OnTriggerStay(Collider other){
            
            if (other.gameObject.tag == "HealthPotion" && (Input.GetKey(KeyCode.E))){
                {
                    player.currentHealthPotion += 1;
                    Debug.Log("Picked up potion");
                    Destroy(other.gameObject);
                }
             }
         }
}
