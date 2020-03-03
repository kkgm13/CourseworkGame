using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PickUpController : MonoBehaviour
{
    public int degrees;
    public Text ScoreText;
    private int currentScore = 0;
    public AudioSource collectSound;

    void Awake(){
        collectSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + currentScore;

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Coin Around
        transform.Rotate(0,degrees*Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collectSound.Play();
            Debug.Log("Sound Effect Played? "+collectSound.isPlaying);
            currentScore += 10;
            ScoreText.text = "Score: " + currentScore;
            // Deleting without playing sound
            Destroy(this.gameObject);
        }
    }
}
