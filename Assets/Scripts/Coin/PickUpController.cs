﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PickUpController : MonoBehaviour
{
    // public int degrees;
    public AudioSource collectSound;
    public int scorePoints;

    void Awake(){
        collectSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collectSound.Play(); // Play Audio
            // ScoringController.currentScore += 10;
            UIController.currentScore += scorePoints;
            Destroy(gameObject, (collectSound.clip.length/12)); // Delay overloads required to play sounds
        }
    }
}
