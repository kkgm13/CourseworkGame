using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    public Text timeText;
    public int degrees;
    public AudioSource collectSound;
    public GameObject scoreText;
    public static int currentScore;
    

    // Start is called before the first frame update
    void Start(){
        collectSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        float time = Time.timeSinceLevelLoad;
        // int hour = (int) ; // Hour???
        int minute = (int) ((time / 60) % 60);
        int seconds = (int) (time % 60);

        timeText.text = string.Format("{0:D1}:{1:D2}",minute,seconds);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            collectSound.Play(); // Play Audio
            ScoringController.currentScore += 10;
            Destroy(gameObject, (collectSound.clip.length/12)); // Delay overloads required to play sounds
        }
    }
}
