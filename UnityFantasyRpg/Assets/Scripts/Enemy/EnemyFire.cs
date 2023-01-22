using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject m_projectilePrefab;

    private float m_shotDelay = 0.0f;
    public float m_rateOfFire = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_shotDelay <= 0){
            Shoot();
            m_shotDelay = 1.0f/m_rateOfFire;
        }else{
            m_shotDelay -= Time.deltaTime;
        }

    }

    void Shoot ()
    {
        Instantiate(m_projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
