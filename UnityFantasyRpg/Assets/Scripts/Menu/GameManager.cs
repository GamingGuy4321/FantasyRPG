using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance = null;
    public GameObject m_LoseMenu;
    public bool m_isLost;

    void Awake() {
        SetInstance();
    }

    void Start(){
        m_LoseMenu.SetActive(false);
    }

    void SetInstance(){
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

   
    public void ResetGame() {
        if(m_isLost) {
            Time.timeScale = 1;
            m_isLost = false;
            m_LoseMenu.SetActive(false);
        }
    }

    public void LoseGame() {
        if (!m_isLost) {
            Time.timeScale = 0;
            m_isLost = true;
            m_LoseMenu.SetActive(true);
        }
    }
}
