using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseController : MonoBehaviour
{

    public GameObject canvas;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            // If true to both Canvas is active and isPaused boolean is true
            if(canvas.gameObject.activeInHierarchy || isPaused == true){
                // Show Gameplay
                Time.timeScale = 1.0f; //  Start Clock Real Time
                canvas.gameObject.SetActive(false);
                // Hide Cursor
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                isPaused = false;
            } else {
                // Show Pause Menu
                Time.timeScale = 0.0f; //  Stop Clock FULLY
                canvas.gameObject.SetActive(true);
                // Show Cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                isPaused = true;
            }
        }
    }

    void Resume(){
        Time.timeScale = 1.0f; //  Resume Real Clock time
        canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        isPaused = false;
    }
}
