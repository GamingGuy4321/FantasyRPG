using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject enemy;

    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health){
        slider.value = health;
    }

    void Update() {
        SetHealth(enemy.GetComponent<AiHitDetection>().currentHealth);
    }
}
