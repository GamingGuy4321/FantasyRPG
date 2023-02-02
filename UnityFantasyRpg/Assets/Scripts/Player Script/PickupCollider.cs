using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollider : MonoBehaviour
{

   public PlayerCharacter player; 

   public Animator Door;
   public Animator Door2;
   public Animator Door3;
   public Animator Door4;

   void OnTriggerStay(Collider other){
            
        if (other.gameObject.tag == "HealthPotion" && (Input.GetKey(KeyCode.E))){
            {
                player.currentHealthPotion += 1;
                Debug.Log("Picked up health potion");
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "ManaPotion" && (Input.GetKey(KeyCode.E))){
            {
                player.currentManaPotion += 1;
                Debug.Log("Picked up mana potion");
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "Coin" && (Input.GetKey(KeyCode.E))){
            {
                player.currentCoins += 1;
                Debug.Log("Picked up coin");
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "TormentedDoor" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 1){
                    Debug.Log("Released Tormented Soul");
                    Door.SetTrigger("DoorOpen");
                }
               
            }
        }

        if (other.gameObject.tag == "GoblinWarchiefDoor" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 10){
                    Debug.Log("Released Warchief");
                    Door2.SetTrigger("Door2Open");
                }
               
            }
        }

        if (other.gameObject.tag == "GolemDoorLeft" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 20){
                    Door3.SetTrigger("Door3Open");
                }
               
            }
        }

        if (other.gameObject.tag == "GolemDoorRight" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 40){
                    Debug.Log("Released Golem");
                    Door4.SetTrigger("Door4Open");
                }
               
            }
        }
    }

    
}
