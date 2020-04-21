using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public int degrees;
    
    // Update is called once per frame
    void Update(){
        transform.Rotate(0,degrees*Time.deltaTime,0);
    }
}
