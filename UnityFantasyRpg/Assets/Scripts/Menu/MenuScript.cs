using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    // Reference to the PauseScreen game object
    public GameObject m_menuScreen;
    // Reference to the SettingsScreen game object
    public GameObject m_settingsScreen;
    // Variables
    [HideInInspector]
    public bool m_menuScreenIsActive = true;
    [HideInInspector]
    public bool m_settingsScreenIsActive = false;

    void Start(){
        m_menuScreen.SetActive(true);
        m_settingsScreen.SetActive(false);
    }

    public void SwitchToSettingsScreen() {
        m_menuScreen.SetActive(false);
        m_settingsScreen.SetActive(true);
        m_menuScreenIsActive = false;
        m_settingsScreenIsActive = true;
    }
    public void SwitchToMenuScreen() {
        m_menuScreen.SetActive(true);
        m_settingsScreen.SetActive(false);
        m_menuScreenIsActive = true;
        m_settingsScreenIsActive = false;
    }
    
}
