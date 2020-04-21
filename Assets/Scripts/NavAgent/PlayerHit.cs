using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    public AudioClip deathAudio;
    new private AudioSource audio;
    
    public GameObject GameOverCanvas;

    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    public void GameOver(){
        audio.PlayOneShot(deathAudio);
        SceneManager.LoadSceneAsync(4);
    }
}
