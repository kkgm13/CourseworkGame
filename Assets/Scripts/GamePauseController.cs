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
            // If true to both
            if(canvas.gameObject.activeInHierarchy || isPaused != false){
                Time.timeScale = 1.0f; //  Stop Clock
                canvas.gameObject.SetActive(false);
                // Hide Cursor
                // Cursor.lockState = CursorLockMode.Confined;
                // Cursor.visible = false;
                 Cursor.visible = false;
                 Screen.lockCursor = true;
                isPaused = false;
            } else {
                Time.timeScale = 0.0f; //  Start Clock
                canvas.gameObject.SetActive(true);
                // SHow Cursor
                // Cursor.lockState = CursorLockMode.None;
                // Cursor.visible = true;
                Cursor.visible = true;
                Screen.lockCursor = false;
                isPaused = true;
            }
        }
    }

    void Resume(){
        Time.timeScale = 1.0f; //  Resume Clock time
        canvas.gameObject.SetActive(false);
        // Cursor.lockState = CursorLockMode.Confined;
        // Cursor.visible = false;
        Cursor.visible = false;
        Screen.lockCursor = true;
        isPaused = false;
    }
}
