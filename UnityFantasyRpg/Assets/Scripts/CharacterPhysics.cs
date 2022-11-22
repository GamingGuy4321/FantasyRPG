using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(CharacterController))]
 
public class CharacterPhysics : MonoBehaviour
{

     Vector3 moveVector;
     CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

     void Update () {
 
         //REeset the MoveVector
         moveVector = Vector3.zero;
 
         //Check if cjharacter is grounded
         if (controller.isGrounded == false)
         {
             //Add our gravity Vecotr
             moveVector += Physics.gravity;
         }
 
         //Apply our move Vector , remeber to multiply by Time.delta
         controller.Move(moveVector * Time.deltaTime);
 
         
     }
}
