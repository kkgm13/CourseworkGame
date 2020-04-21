using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PickUpController : MonoBehaviour
{
    public int degrees;
    public AudioSource collectSound;

    void Awake(){
        collectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Coin Around
        transform.Rotate(0,degrees*Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collectSound.Play(); // Play Audio
            ScoringController.currentScore += 10;
            Destroy(gameObject, (collectSound.clip.length/12)); // Delay overloads required to play sounds
        }
    }
}
