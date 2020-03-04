using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PickUpController : MonoBehaviour
{
    public int degrees;
    public AudioSource collectSound;

    // Update is called once per frame
    void Update()
    {
        // Rotate Coin Around
        transform.Rotate(0,degrees*Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            Debug.Log("Sound Has Played? "+collectSound.isPlaying);
            collectSound.Play(); // Issue: Sound detects, but doesnt play during play
            Debug.Log("Sound Has Played? "+collectSound.isPlaying);

            ScoringController.currentScore += 10;
            // Deleting without playing sound
            Destroy(gameObject);
        }
    }
}
