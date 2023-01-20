using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TageCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform){
             t.gameObject.tag = "Player";
        }
            gameObject.tag = "Player";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
