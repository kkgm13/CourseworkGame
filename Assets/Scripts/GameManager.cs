using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform player;
    int score = 0;
    float time = 0f;

    void Awake(){
        if (Instance == null){
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        UIManager.Instance.UpdateScore(score);
    }

    // Update is called once per frame
    void Update(){
        time = Time.timeSinceLevelLoad;
        UIManager.Instance.UpdateTimer(time);
    }

    public void IncreaseScore(){
        score += 10;
        UIManager.Instance.UpdateScore(score);
    }

    void TimerTick(){
        if(time > 0f){
            // UIManager.Instance.UpdateTimer(timer);
        } else {
            CancelInvoke("TimerTick");
            // StartCoroutine(GameOverCR());
        }
    }

    // IEnumerator GameOverCR(){
    //     yield return new WaitForSeconds(1f);
    //     StartCoroutine(RemoteScoreManager.Instance.GetHighScoreCR(GetHighScoreComplete));
    // }

    void GetHighScoreComplete(int NScore){
        if(score > NScore){
            // StartCoroutine(RemoteScoreManager.Instance.SetHighScoreCR(score, SetHighScoreComplete));
        } else {
            
        }
    }


    void SetHighScoreComplete(){
        SceneManager.LoadSceneAsync(0);
    }
}
