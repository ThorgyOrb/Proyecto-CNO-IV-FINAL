using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip destruction;
    public AudioClip balazo;
    public static AudioManager Instance;
    public AudioSource audioSource;
    void Awake(){
        Instance=this;
    }

    public void PlayDestruction(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(destruction, 0.3f);
    }
    public void PlayBalazo(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(balazo, 0.3f);
    }
}
