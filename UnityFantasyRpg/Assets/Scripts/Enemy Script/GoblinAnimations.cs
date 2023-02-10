using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimations : MonoBehaviour
{

    public EnemyGoblin enemyGoblin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightAttack(){
        enemyGoblin.isLightAttack = true;
    }

    void LightAttack2(){
        enemyGoblin.isLightAttack2 = true;
    }

    void HeavyAttack(){
        enemyGoblin.isHeavyAttack = true;
    }
}
