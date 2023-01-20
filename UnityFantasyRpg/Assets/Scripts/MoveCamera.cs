using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public Vector2 turn;
    public float sensitivity = 20.0f;
    public Vector3 deltaMove;
    public float speed = 1;
    public float value;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        deltaMove = new Vector3(0,0,Input.GetAxisRaw("Vertical")*speed * Time.deltaTime);
        transform.Translate(deltaMove);
    }
}

