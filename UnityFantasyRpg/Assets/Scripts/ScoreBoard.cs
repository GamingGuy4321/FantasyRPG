using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI highScoreUI;

    public float score;
    public float highScore;


    // public float pointsPerSecond=20;

    void Update()
        {
            // score += pointsPerSecond * Time.deltaTime;
            currentScoreUI.text = score.ToString("0");
            highScoreUI.text = highScore.ToString("0");

            if (highScore < score){
            highScore = score;
             }
    
        }

    void OnDestroy() {
        PlayerPrefs.SetFloat("score", highScore);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("score")){
            highScore = PlayerPrefs.GetFloat("score");
        }
    }

    public void AddScore(float score){
        this.score += score;
    }
}
