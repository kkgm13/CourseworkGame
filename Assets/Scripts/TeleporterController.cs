using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour
{
    public int sceneNum;
    
    void OnTriggerEnter(Collider collider){
        SceneManager.LoadSceneAsync(sceneNum);
    }
}
