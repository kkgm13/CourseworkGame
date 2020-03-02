using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider masterSlide;
    public Slider volumeSlide;
    public Slider effectsSlide;

    public static AudioManager INSTANCE;
    private float master;

    void Awake(){
        if(AudioManager.INSTANCE == null){
            DontDestroyOnLoad(gameObject);
            AudioManager.INSTANCE = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        master = PlayerPrefs.GetFloat("MasterVol", masterSlide.value);
        // Set the Mixer volume (as Log10)
        mixer.SetFloat("MasterVol", Mathf.Log(master) * 20);

        AdjustMusicVolume(master);
    }

    // Update is called once per frame
    void Update()
    {
        // Set the master as the new master slide 
        master = PlayerPrefs.GetFloat("MasterVol", masterSlide.value);
        // mixer.volume = masterSlide.value;
    }

    // public void VolumePrefs(){
    //     // PlayerPrefs.SetFloat("MasterVolume", masterSlide.volume);
    //     // PlayerPrefs.SetFloat("MusicVolume", volumeSlide.volume);
    //     // PlayerPrefs.SetFloat("FxVolume", effectsSlide.volume);
    // }

    public void AdjustMusicVolume(float masterVol){
        mixer.SetFloat("MasterVol", Mathf.Log(masterVol) * 20);
        PlayerPrefs.SetFloat("MasterVol", masterVol);

        PlayerPrefs.Save();
    }

}
