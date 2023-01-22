using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{

    public GameManager m_gameManager;
    public float m_projectileSpeed = 1.0f;
    public Rigidbody2D rb;
    public float ShotDestroy;

    // Start is called before the first frame update
    void Start()
    {  m_gameManager = FindObjectOfType<GameManager>();
        rb.velocity = transform.up * Time.fixedDeltaTime * m_projectileSpeed;
    }

    void Update() {
        Object.Destroy(gameObject, ShotDestroy);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag =="Player"){
         Destroy(other.gameObject); // this destroys the enemy
         Destroy(gameObject); // this destroys the bullet
         m_gameManager.LoseGame();
         }

         if (other.gameObject.tag =="Shield"){
         Destroy(gameObject); // this destroys the bullet
         }

         if (other.gameObject.tag =="Asteroid"){
         Destroy(other.gameObject); // this destroys the enemy
         Destroy(gameObject); // this destroys the bullet
         }
    }
    

}
