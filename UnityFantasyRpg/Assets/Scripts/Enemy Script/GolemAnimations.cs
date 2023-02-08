using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimations : MonoBehaviour
{


    public EnemyGolem enemyGolem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwipeEvent(){
        enemyGolem.isSwiping = true;
    }

    void SlamLand(){
        enemyGolem.isSlaming = true;
    }

    void Jump(){
        enemyGolem.isJumping = true;
    }
}
