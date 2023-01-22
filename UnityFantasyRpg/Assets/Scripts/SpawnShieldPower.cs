using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShieldPower : MonoBehaviour
{
    public GameObject m_ShieldPowerUpPrefab;

    private float m_startTime;
    private float m_timertime;

    public float m_minXLocation = -17.0f;
    public float m_maxXLocation =  17.0f;
    public float m_minYLocation = -9.0f;
    public float m_maxYLocation =  9.0f;

    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        m_startTime = Time.time;
        m_timertime = Random.Range(3.5f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - m_startTime > m_timertime)
        {
            go = Instantiate(m_ShieldPowerUpPrefab, new Vector3(Random.Range(m_minXLocation,m_maxXLocation),Random.Range(m_minYLocation,m_maxYLocation), 1f), Quaternion.identity);
            m_startTime = Time.time;
        }

        Destroy(go, 5.0f);
    }
}
