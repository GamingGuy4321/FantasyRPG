using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] m_AsteroidPrefab = new GameObject[4];

    private float m_startTime;
    private float m_timertime;

    public float m_xLocation = -18.0f;
    public float m_minYLocation = -10.0f;
    public float m_maxYLocation = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_startTime = Time.time;
        m_timertime = Random.Range(1.0f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - m_startTime > m_timertime){
            Instantiate(m_AsteroidPrefab[Random.Range(0, m_AsteroidPrefab.Length)], new Vector3((m_xLocation),Random.Range(m_minYLocation,m_maxYLocation), 1f), Quaternion.identity);
            m_startTime = Time.time;
        }
    }
}
