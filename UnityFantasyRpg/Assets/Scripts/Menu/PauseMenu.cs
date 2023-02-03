using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Reference to the PauseScreen game object
    public GameObject m_pauseScreen;
    // Reference to the SettingsScreen game object
    public GameObject m_settingsScreen;
    // Variables
    [HideInInspector]
    public bool m_pauseScreenIsActive = true;
    [HideInInspector]
    public bool m_settingsScreenIsActive = false;

    void Start(){
        m_pauseScreen.SetActive(true);
        m_settingsScreen.SetActive(false);
    }

    public void SwitchToSettingsScreen() {
        m_pauseScreen.SetActive(false);
        m_settingsScreen.SetActive(true);
        m_pauseScreenIsActive = false;
        m_settingsScreenIsActive = true;
    }
    public void SwitchToPauseScreen() {
        m_pauseScreen.SetActive(true);
        m_settingsScreen.SetActive(false);
        m_pauseScreenIsActive = true;
        m_settingsScreenIsActive = false;
    }
    
}
