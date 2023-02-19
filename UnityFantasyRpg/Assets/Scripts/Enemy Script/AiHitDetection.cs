using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHitDetection : MonoBehaviour
{
    public Animator m_animator;

    public float maxHealth;
    public float currentHealth;
    private Healthbar healthbar;
    public Transform coinSpawn;
    public GameObject coinPrefab;
    AudioSource audioSource;

    [SerializeField]
    public AudioClip[] swordHitClips;

    void OnTriggerEnter(Collider other) {

         if (other.gameObject.tag == "Melee"){
            print("Enemy was hit with light attack!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 10.0f;
            swordHit();
        }

        if (other.gameObject.tag == "MeleeTwo"){
            print("Enemy was hit with light attack!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 40.0f;
            swordHit();
        }
        
        if (other.gameObject.tag == "IceBolt"){
            print("Enemy was hit with Ice Bolt!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 30.0f;
        }
        if (other.gameObject.tag == "IceSlam"){
            print("Enemy was hit with Ice Slam!");
            m_animator.SetTrigger("isHit");
            currentHealth -= 75.0f;
        }
        if (currentHealth <= 0){
            m_animator.SetTrigger("isDead");
            Instantiate(coinPrefab, coinSpawn.position, coinSpawn.rotation);
            Destroy(gameObject);
        }

        void OnTriggerStay(Collider other) {
            if (other.gameObject.tag == "KnifeHail"){
            print("Enemy was hit with Knife Hail!");
            m_animator.SetTrigger("isHit");
            currentHealth --;
        }
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if(healthbar != null){
            healthbar.SetMaxHealth(maxHealth);
        }
        m_animator = GetComponent<Animator>();
    }

    public void swordHit(){
       AudioClip clip = GetRandomClipSwordHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipSwordHit(){
        return swordHitClips[UnityEngine.Random.Range(0, swordHitClips.Length)];
    }

}
