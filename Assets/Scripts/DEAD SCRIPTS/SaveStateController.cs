using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[Serializable]
public struct FPSState {
    public Vector3 position;
    public Quaternion rotation;

    public FPSState(Vector3 position, Quaternion rotation){
        this.rotation = rotation;
        this.position = position;
    }
}

[Serializable]
public struct CoinState{
    public Vector3 position;
    public Quaternion rotation;

    public CoinState(Vector3 position, Quaternion rotation){
        this.rotation = rotation;
        this.position = position;
    }
}

[Serializable]
public struct GameState {
    public CoinState[] coinStates;
    public FPSState fpsState;
    
    public GameState(CoinState[] coinStates, FPSState fpsState){
        this.coinStates = coinStates;
        this.fpsState = fpsState;
    }
}

public class SaveStateController : MonoBehaviour
{

    [SerializeField]
    public GameObject fps;

    private const string SAVEGAME_FILE = "Assets/Saves/savedfile.xml";
    private const string MASTERSAVE_FILE = "Assets/Saves/saveFiles.xml";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)){
            Save(SAVEGAME_FILE);
        } else if (Input.GetKeyDown(KeyCode.F2)){
            Load(SAVEGAME_FILE);
        }
    }

    // private GameState ToRecord(){
    //     GameObject[] coins = FindObjectsOfType<PickUpController>();
    //     CoinState[] coinStates = new CoinStatep[coins.Length];
    //     for (int i = 0; i < coins.length; i++){
    //         if(coins[i] != null){
    //             CoinState state = new CoinState(transform.position, transform.rotation, name, coins[i].name);
    //             coinStates[i] = state;
    //         } else {
    //             CoinState state = new CoinState(transform.position, transform.rotation, name, "null");
    //             coinStates[i] = state;
    //         }
    //     }

    //     GameState gs = new GameState(coinStates);
    //     XmlDocument xml = new XmlDocument();
    //     XmlSerializer serial = new XmlSerializer(typeof(GameState));
    //     using(MemoryStream stream = new MemoryStream()){
    //         serial.Serialize(stream, gs);
    //         stream.Position = 0;
    //         xml.Load(stream);
    //         xml.save(filename);
    //     }

    //     return new GameState(coinStates);
    // }

    public void FromRecord(GameState state){
        // ClearScene();
        // Dictionary<string, GameObject> objects = CreateObjects(state);
        // Dictionary<string,string> links = CreateLinks(state);
        // LinkObjects(links, objects);
    }


    private void Save(string filename){
        XmlDocument doc = new XmlDocument();
        FPSState state = new FPSState(fps.transform.position, fps.transform.rotation);
        XmlSerializer serial = new XmlSerializer(typeof(FPSState));
        using(MemoryStream stream = new MemoryStream()){
            serial.Serialize(stream, state);
            stream.Position = 0;
            doc.Load(stream);
            doc.Save(filename);
        }
    }

    private void Load(string filename){
        XmlDocument doc = new XmlDocument();
        doc.Load(filename);
        string xmlString = doc.OuterXml;
        FPSState state;
        using (StringReader read = new StringReader(xmlString)){
            XmlSerializer serial = new XmlSerializer(typeof(FPSState));
            using(XmlReader reader = new XmlTextReader(read)){
                state = (FPSState)serial.Deserialize(reader);
            }
        }
        fps.transform.position = state.position;
        fps.transform.rotation = state.rotation;
    }
}
