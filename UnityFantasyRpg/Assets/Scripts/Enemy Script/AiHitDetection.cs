using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHitDetection : MonoBehaviour
{
    public Animator m_animator;

    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public Transform coinSpawn;
    public GameObject coinPrefab;


    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "IceBolt"){
            print("Enemy was hit with Ice Bolt!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 30;
        }
        if (other.gameObject.tag == "IceSlam"){
            print("Enemy was hit with Ice Slam!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 75;
        }
        if (other.gameObject.tag == "KnifeHail"){
            print("Enemy was hit with Knife Hail!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 2;
        }
        if (currentHealth <= 0){
            m_animator.SetTrigger("isDead");
            Instantiate(coinPrefab, coinSpawn.position, coinSpawn.rotation);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
