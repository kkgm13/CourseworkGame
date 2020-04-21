using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AudioClip deathAudio;
    new private AudioSource audio;
    
    public GameObject GameOverCanvas;
    // private bool isPaused = false;

    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    public void GameOver(){
        audio.PlayOneShot(deathAudio);
    }
}
