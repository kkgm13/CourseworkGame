using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        if(collision.tag == "Player"){
            collision.GetComponent<PlayerHit>().GameOver();
        }
    }
}
