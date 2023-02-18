using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnimations : MonoBehaviour
{
    public EnemyMeleeAttack enemyMeleeAttack;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightAttack(){
        enemyMeleeAttack.isLightAttack = true;
    }

    void HeavyAttack(){
        enemyMeleeAttack.isHeavyAttack = true;
    }
}
