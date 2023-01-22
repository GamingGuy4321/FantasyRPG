using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    public GameObject m_BlueEnemyPrefab;
    public GameObject m_GreenEnemyPrefab;
    public GameObject m_RedEnemyPrefab;

    private float m_startTime1;
    private float m_startTime2;
    private float m_startTime3;
    private float m_bluetimertime;
    private float m_redtimertime;
    private float m_greentimertime;

    // Start is called before the first frame update
    void Start()
    {
        m_startTime1 = Time.time;
        m_startTime2 = Time.time;
        m_startTime3 = Time.time;
        m_bluetimertime = Random.Range(2.5f, 4.5f);
        m_redtimertime = Random.Range(5.5f, 7.5f);
        m_greentimertime = Random.Range(4.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - m_startTime1 > m_bluetimertime){
            Instantiate(m_BlueEnemyPrefab, transform.position, Quaternion.identity);

            m_startTime1 = Time.time;

        }

         if(Time.time - m_startTime2 > m_redtimertime){
            Instantiate(m_RedEnemyPrefab, transform.position, Quaternion.identity);

            m_startTime2 = Time.time;
         }

         if(Time.time - m_startTime3 > m_greentimertime){
            Instantiate(m_GreenEnemyPrefab, transform.position, Quaternion.identity);

            m_startTime3 = Time.time;
         }
    }
}
