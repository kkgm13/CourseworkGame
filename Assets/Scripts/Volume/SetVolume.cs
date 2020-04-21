using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixerName;

    public Slider slider;

    public void SetLevel(float sliderVal){
        
        mixer.SetFloat(
            // Provide Mixer Name
            mixerName,
            // Slider Value as a Log base of 10 & multiply by 20
            Mathf.Log10(sliderVal) * 20
        );

        // Set the PlayerPref Volume
        PlayerPrefs.SetFloat(mixerName, sliderVal);

        // Save PlayerPrefs
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the Slider value based on the PlayerPref Information
        slider.value = PlayerPrefs.GetFloat(mixerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
