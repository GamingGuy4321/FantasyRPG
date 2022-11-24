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

    //  private CharacterController _controller;
    //  [SerializeField]
    //  private float _speed = 5f;
    //  [SerializeField]
    //  private float _jumptHeight = 15f;
    //  private float _yVelocity;
    //  private float _gravity = 1f;

    // void Start() {
        
    // }
    
    //  void Update (){

    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     Vector3 direction = new Vector3(horizontalInput,0,0);
    //     Vector3 velocity = direction *_speed;

    //      //Check if character is grounded
    //      if(_controller.isGrounded)
    //      {
    //         if(Input.GetKeyDown(KeyCode.Space)){
    //              _yVelocity = _jumptHeight;
    //         }
    //      }
    //      else
    //      {
    //         _yVelocity -= _gravity;
    //      }

    //      velocity.y = _yVelocity;
 
    //      //Apply our move Vector , remeber to multiply by Time.delta
    //      _controller.Move(velocity * Time.deltaTime);
    //  }