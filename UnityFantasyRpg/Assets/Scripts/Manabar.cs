using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
public Slider slider;

        public void SetManaHealth(int health){
            slider.maxValue = health;
            slider.value = health;
        }
        public void SetMana(int health){
            slider.value = health;
        }
}
