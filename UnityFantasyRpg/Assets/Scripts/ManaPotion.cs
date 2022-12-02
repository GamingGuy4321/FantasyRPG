using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    // Update is called once per frame
    public PlayerCharacter player; 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerStay");
            if (Input.GetKey(KeyCode.E))
            {
                player.currentManaPotion += 1;
                Debug.Log("Picked up potion");
                Destroy(this.gameObject);
            }
        }
    }
}
