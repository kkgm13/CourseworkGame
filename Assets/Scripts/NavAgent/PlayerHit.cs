using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlayerHit : MonoBehaviour
{
    public AudioClip deathAudio;
    new private AudioSource audio;
    public Text scoreText;

    void Awake(){
        audio = GetComponent<AudioSource>();
    }

    public void GameOver(){
        audio.PlayOneShot(deathAudio);
        SaveScorePlayerPref();
        // StartCoroutine(RemoteScoreManager.Instance.GetHighScoreBKD(GetHighScoreCompleted));
        SceneManager.LoadSceneAsync(4);
    }

    private int GetPlayedScore(){
        string score = Regex.Match(scoreText.text, @"\d+").Value;
        return int.Parse(score);
    }

    void GetHighScoreCompleted(int highScore){
        if(GetPlayedScore() > highScore){
            StartCoroutine(RemoteScoreManager.Instance.SetHighScoreBKD(GetPlayedScore(), SetHighScoreCompleted));
        } else {
            SceneManager.LoadSceneAsync(4);
        }
    }

    void SetHighScoreCompleted(){
        SceneManager.LoadSceneAsync(4);
    }

    private void SaveScorePlayerPref(){
        if(GetPlayedScore() > PlayerPrefs.GetInt("TopScore") || ! PlayerPrefs.HasKey("TopScore")){
            PlayerPrefs.SetInt("TopScore", GetPlayedScore());
            PlayerPrefs.Save();
        }
        SetHighScoreCompleted();
    }
}
