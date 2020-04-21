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
        SceneManager.LoadSceneAsync(4);
    }

    private void SaveScorePlayerPref(){
        string score = Regex.Match(scoreText.text, @"\d+").Value;
        // score = int.Parse(score);
        if(int.Parse(score) > PlayerPrefs.GetInt("TopScore") || ! PlayerPrefs.HasKey("TopScore")){
            PlayerPrefs.SetInt("TopScore", int.Parse(score));
            PlayerPrefs.Save();
        }
    }
}
