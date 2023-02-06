using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject PotionPrefab;
    
    public Vector3 center;
    public Vector3 size;

    public int maxPotions = 10; 
    private int PotionSpawned = 0; 

    void Start() {
        center = transform.position;
    }
    public void SpawnPotion(){
        Vector3 pos = center + new Vector3(Random.Range(-size.x/2, size.x/2), Random.Range(-size.y/2, size.y/2), Random.Range(-size.z/2, size.z/2));

        if(PotionSpawned <= maxPotions){
            Instantiate(PotionPrefab, pos, Quaternion.identity);
            PotionSpawned++;
        }
    }

    void Update(){
       SpawnPotion();
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition, size);
    }
}
