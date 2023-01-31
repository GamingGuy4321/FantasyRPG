using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    public PlayerCharacter player;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4 = 5;
    bool isCooldown4 = false;
    public KeyCode ability4;

    [Header("Ability 5")]
    public Image abilityImage5;
    public float cooldown5 = 5;
    bool isCooldown5 = false;
    public KeyCode ability5;

    [Header("Coin")]
    public PlayerCharacter playerCharacter;
    public TMP_Text coinText;


    // Start is called before the first frame update
    void Start()
    {
       abilityImage1.fillAmount = 0; 
       abilityImage2.fillAmount = 0; 
       abilityImage3.fillAmount = 0; 
       abilityImage4.fillAmount = 0; 
       abilityImage5.fillAmount = 0; 
       playerCharacter = (PlayerCharacter)FindObjectOfType(typeof(PlayerCharacter));
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();
        Ability5();
        Coincount();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown == false)
        {
            if(player.currentHealthPotion >= 1){
                isCooldown = true;
                abilityImage1.fillAmount = 1;
            }
        }

        if(isCooldown){
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Ability2()
    {
        if(Input.GetKey(ability2) && isCooldown2 == false)
        {
            if(player.currentManaPotion >= 1){
                isCooldown2 = true;
                abilityImage2.fillAmount = 1;
            }
        }

        if(isCooldown2){
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if(abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if(Input.GetKey(ability3) && isCooldown3 == false)
        {
                if (player.currentMana >= 20){
                    isCooldown3 = true;
                    abilityImage3.fillAmount = 1;
                }
        }

        if(isCooldown3){
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if(abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Ability4()
    {
        if(Input.GetKey(ability4) && isCooldown4 == false)
        {
            if (player.currentMana >= 50){
                isCooldown4 = true;
                abilityImage4.fillAmount = 1;
            }
        }

        if(isCooldown4){
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if(abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }

    void Ability5()
    {
        if(Input.GetKey(ability5) && isCooldown5 == false)
        {
            if (player.currentMana >= 35){
                isCooldown5 = true;
                abilityImage5.fillAmount = 1;
            }
        }

        if(isCooldown5){
            abilityImage5.fillAmount -= 1 / cooldown5 * Time.deltaTime;

            if(abilityImage5.fillAmount <= 0)
            {
                abilityImage5.fillAmount = 0;
                isCooldown5 = false;
            }
        }
    }

    void Coincount(){

        coinText.text = (playerCharacter.currentCoins.ToString());
    }
}
