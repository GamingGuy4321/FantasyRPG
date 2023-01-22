using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameManager m_gameManager;

    public float m_xscrollSpeed = 5.0f;

    public bool m_isMovingLeft; 


    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += transform.right * m_xscrollSpeed * Time.deltaTime;
            if (transform.position.x > 21){
                Destroy(gameObject);
            }
            if (transform.position.x < -21){
                Destroy(gameObject);
            }
    }

     void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag =="Player"){
            Destroy(other.gameObject);
            Destroy(gameObject); 
            m_gameManager.LoseGame();
         }

         if (other.gameObject.tag =="Shield"){
            Destroy(gameObject);
         }

         if (other.gameObject.CompareTag("BlueEnemy")){
         Destroy(other.gameObject); // this destroys the enemy
         Destroy(gameObject); // this destroys the bullet
         }

         if (other.gameObject.CompareTag("GreenEnemy")){
         Destroy(other.gameObject); // this destroys the enemy
         Destroy(gameObject); // this destroys the bullet
         }

         if (other.gameObject.CompareTag("RedEnemy")){
         Destroy(other.gameObject); // this destroys the enemy
         Destroy(gameObject); // this destroys the bullet
         }
     }
}
