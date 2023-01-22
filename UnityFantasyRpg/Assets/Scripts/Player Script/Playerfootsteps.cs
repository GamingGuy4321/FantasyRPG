using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfootsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] grassClips;
    [SerializeField]
    private AudioClip[] gravelClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] stoneClips;

    [SerializeField]
    private AudioClip[] runninggrassClips;
    [SerializeField]
    private AudioClip[] runninggravelClips;
    [SerializeField]
    private AudioClip[] runningmudClips;
    [SerializeField]
    private AudioClip[] runningstoneClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    private void Step (){
        AudioClip clip = GetRandomClipwalking();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClipwalking(){

        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch(terrainTextureIndex)
        {
            case 0:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
                
            case 1:
                
            case 2:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            case 3:

            case 4:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 5:
                return gravelClips[UnityEngine.Random.Range(0, gravelClips.Length)];
                
            case 6:
                
            default:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
        }
    }

    private void StepRunning (){
        AudioClip clip = GetRandomClipRunning();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClipRunning(){

        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch(terrainTextureIndex)
        {
            case 0:
                return runninggrassClips[UnityEngine.Random.Range(0, runninggrassClips.Length)];
                
            case 1:
                
            case 2:
                return runningstoneClips[UnityEngine.Random.Range(0, runningstoneClips.Length)];
            case 3:

            case 4:
                return runningmudClips[UnityEngine.Random.Range(0, runningmudClips.Length)];
            case 5:
                return runninggravelClips[UnityEngine.Random.Range(0, runninggravelClips.Length)];
                
            case 6:
                
            default:
                return runningstoneClips[UnityEngine.Random.Range(0, runningstoneClips.Length)];
        }
    }
}
