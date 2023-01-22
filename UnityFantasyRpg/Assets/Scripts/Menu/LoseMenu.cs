using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    // Reference to the PauseScreen game object
    public GameObject m_loseScreen;

    // Variables
    [HideInInspector]
    public bool m_loseScreenIsActive = true;


    void Start(){
        m_loseScreen.SetActive(true);
    }

    public void SwitchToLoseScreen() {
        m_loseScreen.SetActive(true);
        m_loseScreenIsActive = true;
    }

    public void StopLoseScreen(){
        m_loseScreen.SetActive(false);
        m_loseScreenIsActive = false;
    }
}
