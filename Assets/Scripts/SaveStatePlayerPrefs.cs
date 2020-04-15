using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStatePlayerPrefs : MonoBehaviour
{

    public GameObject thePlayer;
    public float xPos, yPos, zPos;

    // Start is called before the first frame update
    void Start(){
        
        xPos = PlayerPrefs.GetFloat("PlXPos"); 
        yPos = PlayerPrefs.GetFloat("PlYPos"); 
        zPos = PlayerPrefs.GetFloat("PlZPos");
        thePlayer.transform.position = new Vector3(xPos, yPos, zPos);
    }

    // Update is called once per frame
    void Update(){
        xPos = thePlayer.transform.position.x;
        yPos = thePlayer.transform.position.y;
        zPos = thePlayer.transform.position.z;
    }

    void OnTriggerEnter(Collider collider){
        PlayerPrefs.SetFloat("PlXPos", xPos);
        PlayerPrefs.SetFloat("PlYPos", yPos);
        PlayerPrefs.SetFloat("PlZPos", zPos);
    }
}
