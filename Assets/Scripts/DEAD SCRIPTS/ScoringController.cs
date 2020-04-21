using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringController : MonoBehaviour
{
    public GameObject scoreText;
    public static int currentScore;

    void Start(){
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        scoreText.GetComponent<Text>().text = "Score: " + currentScore;
    }
}
