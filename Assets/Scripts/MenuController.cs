using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Head back to the Main Menu */
    public void ButtonHandlerMenu(){
        SceneManager.LoadSceneAsync(0);
    }
    
    /* Head to Game based on Save State*/
    public void ButtonHandlerContinue(){

    }

    /*Head to Gamplay Scene */
    public void ButtonHandlerPlay(){
        SceneManager.LoadSceneAsync(2);
    }

    /* Head to the Options Scene */
    public void ButtonHandlerOptions(){
        // Async Add
		SceneManager.LoadSceneAsync(1);
	}

    /* Quit the Game */
    public void QuitGame(){
        // save any game data here
     #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }

}
