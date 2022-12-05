using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip destruction;
    public AudioClip balazo;
    public AudioClip pointSound;
    public AudioClip bulletDestroy;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip hurt;
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
    public void PlayPoints(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(pointSound, 0.3f);
    }
    public void PlayJump(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(jumpSound, 0.3f);
    }
    public void PlayDisparo(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(bulletDestroy, 0.2f);
    }
    public void PlayHurtSound(){
        //Plays a specific clip on an Audio Source once
        audioSource.PlayOneShot(hurt, 0.3f);
    }

}
