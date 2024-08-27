using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] MonsterSnorting;
    public AudioClip crystalLineSound;
    public AudioClip iceRising;
    public AudioClip iceBreak;
    public AudioClip crystalShot;
    public AudioClip[] mutantFootstep;
    public AudioClip[] mutantRoar;
    public AudioClip[] mutantCast;
    public AudioClip mutantDie;
    public static SoundManager Instance;
    public SoundManager(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void PlaySound(AudioSource audioSource, AudioClip audioClip){
        audioSource.PlayOneShot(audioClip);
    }
}
