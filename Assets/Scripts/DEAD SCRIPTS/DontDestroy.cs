using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        Scene scene = SceneManager.GetActiveScene();
        if(objs.Length > 1){
            Destroy(this.gameObject);
        } else {
            Debug.Log("Here");
        }
        
        if(scene.buildIndex != 2){
            DontDestroyOnLoad(this.gameObject);
        } else {
            Debug.Log("Hello");
        }
    }
}
