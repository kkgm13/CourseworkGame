using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    
    void Awake(){;
        // Get Active Scene
        Scene currentScene = SceneManager.GetActiveScene();
        // If the Build Index is the Main Menu's Index
        if(currentScene.buildIndex == 0) {
            // Remove the custor locking state
            Cursor.lockState = CursorLockMode.None;
            // Make cursor visible once again
            Cursor.visible = true;
        }
    }

    /* Currently testing Single menu handler system */
    public void menuHandler(int sceneNum){
        switch (sceneNum)
        {
            case 0:
                SceneManager.LoadSceneAsync(0);
                break;
            case 1:
                SceneManager.LoadSceneAsync(1);
                break;
            case 2:
                SceneManager.LoadSceneAsync(2);
                break;
            case -1:
                #if UNITY_EDITOR
                    // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    // Application.Quit() Works on Build
                    Application.Quit();
                #endif
                break;
            default:
                break;
        }
    }

    /* Head back to the Main Menu */
    public void ButtonHandlerMenu(){
        SceneManager.LoadSceneAsync(0);
    }
    
    /* Head to Game based on Save State*/
    public void ButtonHandlerContinue(){

    }

    /* Head to Gamplay Scene */
    public void ButtonHandlerPlay(){
        SceneManager.LoadSceneAsync(2);
    }

    /* Head to the Options Scene */
    public void ButtonHandlerOptions(){
		SceneManager.LoadSceneAsync(1);
	}

    /* Quit the Game */
    public void QuitGame(){
        // save any game data here
     #if UNITY_EDITOR
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
        // Application.Quit() Works on Build
         Application.Quit();
     #endif
    }

}
