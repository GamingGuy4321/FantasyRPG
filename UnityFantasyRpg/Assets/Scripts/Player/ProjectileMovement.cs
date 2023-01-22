using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileMovement : MonoBehaviour
{

    public float m_projectileSpeed = 1.0f;
    public Rigidbody2D rb;
    private ScoreBoard ScoreBoard;

    public AudioClip clip;
    public AudioClip rock;

    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard = FindObjectOfType<ScoreBoard>();
        rb.velocity = transform.up * Time.fixedDeltaTime * m_projectileSpeed;

    }

    void Update() {
        Object.Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("BlueEnemy")){
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
            ScoreBoard.AddScore(100);
            AudioSource.PlayClipAtPoint(clip, transform.position);
         }

         if (other.gameObject.CompareTag("GreenEnemy")){
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
            ScoreBoard.AddScore(250);
            AudioSource.PlayClipAtPoint(clip, transform.position);
         }

         if (other.gameObject.CompareTag("RedEnemy")){
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
            ScoreBoard.AddScore(500);
            AudioSource.PlayClipAtPoint(clip, transform.position);
         }

         if (other.gameObject.CompareTag("Asteroid")){
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
            AudioSource.PlayClipAtPoint(rock, transform.position);
         }

         if (other.gameObject.CompareTag("EnemyLaser")){
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
         }

    }

    

}
