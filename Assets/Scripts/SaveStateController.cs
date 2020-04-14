using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct FPSState
{
    public Vector3 position;
    public Quaternion rotation;

    public FPSState(Vector3 position, Quaternion rotation){
        this.rotation = rotation;
        this.position = position;
    }
} 

public class SaveStateController : MonoBehaviour
{

    [SerializeField]
    public GameObject fps;

    private const string SAVEGAME_FILE = "Assets/Saves/savedfile.xml";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if()
    }
}
