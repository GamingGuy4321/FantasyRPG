using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDelay : MonoBehaviour
{
    public double Timer;
    private double internalTimer;

    void OnDisable() {
        internalTimer = Timer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer -= Time.deltaTime;
        if (internalTimer <= 0){
            gameObject.SetActive(true);
        }
    }
}
