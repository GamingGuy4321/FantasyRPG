using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWarchiefAnimation : MonoBehaviour
{
    public EnemGoblinWarchief enemGoblinWarchief;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightAttack(){
        enemGoblinWarchief.isLightAttack = true;
    }

    void HeavyAttack(){
        enemGoblinWarchief.isHeavyAttack = true;
    }
}
