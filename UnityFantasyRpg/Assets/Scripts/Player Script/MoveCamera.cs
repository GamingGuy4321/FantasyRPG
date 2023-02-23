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

    public GameManager gameManager;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if((gameManager.m_isPaused == false) && (!gameManager.m_isLost) && (!gameManager.m_isWon)){
            Cursor.lockState = CursorLockMode.Locked;
            
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
        }
    }
}

