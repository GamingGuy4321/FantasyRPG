using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       
using UnityEngine.Audio;    
using TMPro;                
public class SettingsManager : MonoBehaviour
{
    private Resolution[] m_resolutions;
    private string[] m_qualitySettings;
    public TMP_Dropdown m_resolutionsDropdown;
    public TMP_Dropdown m_qualityDropdown;
    public Toggle m_fullscreenToggle;
    
    void Start(){
        
        ConfigureResolutions();
        ConfigureQualitySettings();
        SetFullscreen(Screen.fullScreen);

        if(PlayerPrefs.HasKey("Resolution")){
            SetResolution(PlayerPrefs.GetInt("Resolution"));
        }
        if(PlayerPrefs.HasKey("Graphics")){
            SetGraphicsQuality(PlayerPrefs.GetInt("Graphics"));
        }
        if(PlayerPrefs.HasKey("Fullscreem")){
            if(PlayerPrefs.GetInt("Fullscreem") == 1){
                SetFullscreen(true);
            }else {
                SetFullscreen(false);
             }
        }
        if(PlayerPrefs.HasKey("Volume")){
            SetVolume(PlayerPrefs.GetFloat("Volume"));
        }
    }
    
    void ConfigureResolutions(){
        
        m_resolutions = Screen.resolutions;
        m_resolutionsDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
       
        for(int i = 0; i < m_resolutions.Length; i++){
            string option = m_resolutions[i].width + " x " + m_resolutions[i].height;
            resolutionOptions.Add(option);
           
            if(m_resolutions[i].width == Screen.currentResolution.width &&
               m_resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }
        m_resolutionsDropdown.AddOptions(resolutionOptions);
        m_resolutionsDropdown.value = currentResolutionIndex;
        m_resolutionsDropdown.RefreshShownValue();
    }
   
    void ConfigureQualitySettings(){
        m_qualitySettings = QualitySettings.names;
        m_qualityDropdown.ClearOptions();
        List<string> qualityOptions = new List<string>();

        int currentQualityIndex = QualitySettings.GetQualityLevel();
        for(int i = 0; i < m_qualitySettings.Length; i++){
            string option = m_qualitySettings[i];
            qualityOptions.Add(option);
        }
        m_qualityDropdown.AddOptions(qualityOptions);
        m_qualityDropdown.value = currentQualityIndex;
        m_qualityDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = m_resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public void SetGraphicsQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex, true);
        PlayerPrefs.SetInt("Graphics", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        if(isFullscreen){
            PlayerPrefs.SetInt("Fullscreen", 1);
        }else {
            PlayerPrefs.SetInt("Fullscreen",0);
        }

    }

    public void SetVolume(float volume){
        AudioListener.volume=volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
