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
        collectSound.Play();
        if(collider.tag == "Player"){
            ScoringController.currentScore += 10;
            // Deleting without playing sound
            // Destroy(gameObject); // ISSUE: Destroying game object disables the coins audio
        }
    }
}
