 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class HighScoreResult
{
    public int Score;
    public string code;
    public string message;
}

public class RemoteHighScoreManager : MonoBehaviour
{

    public static RemoteHighScoreManager Instance { get; private set; }

    void Awake()
    {
        // force singleton instance
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        // don't destroy this object when we load scene
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator GetHighScoreBKD(Action<int> onCompleteCallback)
    {
        string url = "https://api.backendless.com/"+Globals.APP_ID+"/"+Globals.REST_ID+"/data/DataBase";
        UnityWebRequest webreq = UnityWebRequest.Get(url);
        webreq.SetRequestHeader("application-id", Globals.APP_ID);
        webreq.SetRequestHeader("secret-key", Globals.REST_ID);
        webreq.SetRequestHeader("application-type", "REST");
        yield return webreq.Send();
        if (webreq.isNetworkError){
            Debug.Log(webreq.error);
        } else {
            HighScoreResult highScoreData = JsonUtility.FromJson<HighScoreResult>(webreq.downloadHandler.text);
            if (!string.IsNullOrEmpty(highScoreData.code)) {
                Debug.Log("Error:" + highScoreData.code + " " + highScoreData.message);
            } else {
                onCompleteCallback(highScoreData.Score);
            }
        }
    }

    public IEnumerator SetHighScoreBKD(int score, Action onCompleteCallback)
    {
        string url = "https://api.backendless.com/"+Globals.APP_ID+"/"+Globals.REST_ID+"/data/DataBase";
        string data = JsonUtility.ToJson(new HighScoreResult { Score = score });
        UnityWebRequest webreq = UnityWebRequest.Put(url, data);
        webreq.SetRequestHeader("Content-Type", "application/json");
        webreq.SetRequestHeader("application-id", Globals.APP_ID);
        webreq.SetRequestHeader("secret-key", Globals.REST_ID);
        webreq.SetRequestHeader("application-type", "REST");
        yield return webreq.Send();
        if (webreq.isNetworkError){
            Debug.Log(webreq.error);
        } else {
            HighScoreResult highScoreData = JsonUtility.FromJson<HighScoreResult>(webreq.downloadHandler.text);
            if (!string.IsNullOrEmpty(highScoreData.code)) {
                Debug.Log("Error:" + highScoreData.code + " " + highScoreData.message);
            }else{
                onCompleteCallback();
            }
        }
    }
}