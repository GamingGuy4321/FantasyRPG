using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDelayDisable : MonoBehaviour
{
    public Collider collider;
    public double Timer;
    private double internalTimer;

    void OnEnable() {
        internalTimer = Timer;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer -= Time.deltaTime;
        if (internalTimer <= 0){
            collider.enabled = false;
        }
    }
}
