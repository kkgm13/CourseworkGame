using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStatePlayerPrefs : MonoBehaviour
{

    public GameObject thePlayer;
    public float xPos, yPos, zPos;
    public float xRot, yRot, zRot;

    // Start is called before the first frame update
    void Start(){
        
        xPos = PlayerPrefs.GetFloat("PlXPos"); 
        yPos = PlayerPrefs.GetFloat("PlYPos"); 
        zPos = PlayerPrefs.GetFloat("PlZPos");
        // PlayerPrefs.GetFloat("PlXRot", xRot);
        // PlayerPrefs.GetFloat("PlYRot", yRot);
        // PlayerPrefs.GetFloat("PlZRot", zRot);
        thePlayer.transform.position = new Vector3(xPos, yPos, zPos);
        // thePlayer.transform.rotation = new Quaternion(xRot, yRot, zRot);
    }

    // Update is called once per frame
    void Update(){
        xPos = thePlayer.transform.position.x;
        yPos = thePlayer.transform.position.y;
        zPos = thePlayer.transform.position.z;

        // xRot = thePlayer.transform.rotation.x;
        // yRot = thePlayer.transform.rotation.y;
        // zRot = thePlayer.transform.rotation.z;
        
    }

    void OnTriggerEnter(Collider collider){
        PlayerPrefs.SetFloat("PlXPos", xPos);
        PlayerPrefs.SetFloat("PlYPos", yPos);
        PlayerPrefs.SetFloat("PlZPos", zPos);

        // PlayerPrefs.SetFloat("PlXRot", xRot);
        // PlayerPrefs.SetFloat("PlYRot", yRot);
        // PlayerPrefs.SetFloat("PlZRot", zRot);
    }
}
