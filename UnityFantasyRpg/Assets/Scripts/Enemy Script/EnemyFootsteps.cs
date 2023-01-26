using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] stepClips;

    [SerializeField]
    private AudioClip[] daggerClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step (){
       AudioClip clip = GetRandomClipwalking();
       audioSource.PlayOneShot(clip);
    }
    

    private AudioClip GetRandomClipwalking(){
        return stepClips[UnityEngine.Random.Range(0, stepClips.Length)];
    }

    private void Dagger (){
       AudioClip clip = GetRandomClipdagger();
       audioSource.PlayOneShot(clip);
    }
    

    private AudioClip GetRandomClipdagger(){
        return daggerClips[UnityEngine.Random.Range(0, daggerClips.Length)];
    }
}
