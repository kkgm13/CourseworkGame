using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        SceneManager.LoadSceneAsync(3);
    }
}
