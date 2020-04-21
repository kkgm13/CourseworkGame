using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
    Singleton Class
*/
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}

    public Text timeText;
    public Text scoreText;

    void Awake(){
        if(Instance == null){
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int score){        
        scoreText.text = score.ToString();
    }

    public void UpdateTimer(float time){
        int minute = (int) ((time / 60) % 60);
        int seconds = (int) (time % 60);

        timeText.text = string.Format("{0:D1}:{1:D2}",minute,seconds);
    }
}
