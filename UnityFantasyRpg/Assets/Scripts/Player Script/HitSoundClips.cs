using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundClips : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] swordHitClips;

    [SerializeField]
    public AudioClip[] daggerHitClips;

    [SerializeField]
    public AudioClip[] hammerHitClips;

    [SerializeField]
    public AudioClip[] blockHitClips;

    [SerializeField]
    public AudioClip[] golemHitClips;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void swordHit(){
       AudioClip clip = GetRandomClipSwordHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipSwordHit(){
        return swordHitClips[UnityEngine.Random.Range(0, swordHitClips.Length)];
    }

    public void daggerHit(){
       AudioClip clip = GetRandomClipDaggerHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipDaggerHit(){
        return daggerHitClips[UnityEngine.Random.Range(0, daggerHitClips.Length)];
    }

    public void hammerHit(){
       AudioClip clip = GetRandomClipHammerHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipHammerHit(){
        return hammerHitClips[UnityEngine.Random.Range(0, hammerHitClips.Length)];
    }

    public void blockHit(){
       AudioClip clip = GetRandomClipBlockHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipBlockHit(){
        return blockHitClips[UnityEngine.Random.Range(0, blockHitClips.Length)];
    }

    public void golemHit(){
       AudioClip clip = GetRandomClipGolemHit();
       audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClipGolemHit(){
        return golemHitClips[UnityEngine.Random.Range(0, golemHitClips.Length)];
    }
}
