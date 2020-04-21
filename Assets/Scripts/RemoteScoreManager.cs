using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class ScoreResult {
    public int Score;
    public string code;
    public string message;
}

public class RemoteScoreManager : MonoBehaviour
{
    public static RemoteScoreManager Instance { get; private set; }
    
    void Awake(){
        if(Instance == null){
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public IEnumerator GetCoinScoreCR(Action<int> onCompleteCallback){
        string url = "https://api.backendless.com/"+Globals.APP_ID+"/"+Globals.REST_ID+"/data/DataBase";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("application-id", Globals.APP_ID);
        request.SetRequestHeader("secret-key", Globals.REST_ID);
        request.SetRequestHeader("application-type", "REST");
        yield return request.Send();

        if(request.isNetworkError){
            Debug.Log("Error "+request.responseCode+": "+request.error);
        } else {
            ScoreResult scoreData = JsonUtility.FromJson<ScoreResult>(request.downloadHandler.text);
            if(!string.IsNullOrEmpty(scoreData.code)){
                Debug.Log("Error: "+scoreData.message+"\n("+scoreData.code+")");
            } else {
                onCompleteCallback(scoreData.Score);
            }
        }
    }

    public IEnumerator SetCoinScoreCR(int score, Action onCompleteCallback){
        string url = "https://api.backendless.com/"+Globals.APP_ID+"/"+Globals.REST_ID+"/data/DataBase";
        string data = JsonUtility.ToJson(new ScoreResult { Score = score });
        UnityWebRequest request = UnityWebRequest.Put(url, data);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("application-id", Globals.APP_ID);
        request.SetRequestHeader("secret-key", Globals.REST_ID);
        request.SetRequestHeader("application-type", "REST");
        yield return request.Send();

        if(request.isNetworkError){
            Debug.Log(request.error);
        } else {
            ScoreResult scoreData = JsonUtility.FromJson<ScoreResult>(request.downloadHandler.text);
            if(!string.IsNullOrEmpty(scoreData.code)){
                Debug.Log("Error: " + scoreData.code +" " + scoreData.message);
            } else {
                onCompleteCallback();
            }
        }
    }
}
