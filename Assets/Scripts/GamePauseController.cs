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
            if(isPaused != false){
                Time.timeScale = 0.0f; //  Stop Clock
                canvas.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
                // Hide Cursor
                Cursor.visible = false;
                isPaused = false;
            } else {
                Time.timeScale = 1.0f; //  Start Clock
                canvas.gameObject.SetActive(true);
                // SHow Cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isPaused = true;
            }
        }
    }

    void Resume(){
        Time.timeScale = 1.0f; //  Resume Clock time
        canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        isPaused = false;
    }
}
