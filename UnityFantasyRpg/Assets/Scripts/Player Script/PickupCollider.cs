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

    int maxTormented = 1;
    int tormentedSpawn = 0;

    int maxGoblin = 1;
    int goblinSpawn = 0;

    int maxGolem = 1;
    int golemSpawn = 0;

    public Transform SpawnTormented;
    public Transform SpawnGoblin;
    public Transform SpawnGolem;

   public GameObject TormentedSoul;
   public GameObject GoblinWarchief;
   public GameObject Golem;

    public GameObject Door1Canvas;
    public GameObject Door2Canvas;
    public GameObject Door3Canvas;

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
                if (player.currentCoins >= 8){
                    Debug.Log("Released Tormented Soul");
                    Door.SetTrigger("DoorOpen");
                    Door1Canvas.SetActive(false);
                    if(tormentedSpawn < maxTormented ){
                        Instantiate(TormentedSoul, SpawnTormented.position, Quaternion.identity);
                        tormentedSpawn++;
                    }
                }
               
            }
        }

        if (other.gameObject.tag == "GoblinWarchiefDoor" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 3){
                    Debug.Log("Released Warchief");
                    Door2.SetTrigger("Door2Open");
                    Door2Canvas.SetActive(false);
                    if(goblinSpawn < maxGoblin){
                        Instantiate(GoblinWarchief, SpawnGoblin.position, Quaternion.identity);
                        goblinSpawn++;
                    }

                }
               
            }
        }

        if (other.gameObject.tag == "GolemDoorLeft" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 12){
                    Debug.Log("Released Golem");
                    Door3.SetTrigger("Door3Open");
                    Door3Canvas.SetActive(false);
                    if (golemSpawn < maxGolem){
                        Instantiate(Golem, SpawnGolem.position, Quaternion.identity);
                        golemSpawn++;
                    }
                }
               
            }
        }

        if (other.gameObject.tag == "GolemDoorRight" && (Input.GetKey(KeyCode.E))){
            {
                if (player.currentCoins >= 12){
                    Door4.SetTrigger("Door4Open");
                }
               
            }
        }
    }

    
}
