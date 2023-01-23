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
    public bool turnY = true;
    public bool turnX = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        if (turnX && turnY)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        } else if (turnX && !turnY)
        {
            transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        } else if (!turnX && turnY)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        }
        else if (!turnX && !turnY)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        //deltaMove = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0,Input.GetAxisRaw("Vertical")*speed * Time.deltaTime);
        //transform.Translate(deltaMove);
    }
}

