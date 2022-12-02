using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour{
    
    public Slider slider;
    public PlayerCharacter player;

        public void SetManaHealth(int mana){
            slider.maxValue = mana;
            slider.value = mana;
        }

        public void SetMana(int mana){
            slider.value = mana;
        }

        void Update() {
            SetMana(player.currentMana);
        }
}
