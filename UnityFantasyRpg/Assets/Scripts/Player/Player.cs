using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    
    Rigidbody2D m_rigidbody;

    [HideInInspector]
    public Animator m_animator;

    [HideInInspector]
    public bool m_isMoving = false;

    public GameObject m_PowerUpShield;

    float m_Rotation;
    float m_verticalMovement;

    public float m_moveSpeed = 50.0f;
    public float m_rotationSpeed = 100.0f;
    public float m_scrollSpeed = 5.0f;

    private float m_startTime;

    private float m_shieldTime;

    public bool shieldIsActive = false;

    void Start()
    {
        m_PowerUpShield.SetActive(false);
        shieldIsActive = false;

        m_startTime = Time.time;

        m_shieldTime = 10.0f;

        m_rigidbody = GetComponent<Rigidbody2D>();

        m_animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Menu");
        }

          if(Time.time - m_startTime > m_shieldTime){
            m_PowerUpShield.SetActive(false);
            shieldIsActive = false;

            m_startTime = Time.time;

        }


    }
    
    void FixedUpdate() {
 
       m_verticalMovement = Input.GetAxisRaw("Vertical");
   
       m_rigidbody.velocity = transform.up * Time.fixedDeltaTime * m_moveSpeed * m_verticalMovement;
       
       if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * m_rotationSpeed * Time.deltaTime);
       }
      

       if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
       }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("ShieldPowerup")){
           m_PowerUpShield.SetActive(true);
           shieldIsActive = true;
           Destroy(other.gameObject);
        }
    }

}

