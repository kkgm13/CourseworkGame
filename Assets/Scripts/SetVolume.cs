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
        mixer.SetFloat(mixerName,
        Mathf.Log10(sliderVal) * 20 // Slider Value respresented by the Log base of 10 & multiply by 20
        );

        PlayerPrefs.SetFloat(mixerName, sliderVal);

        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        // masterSlider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(mixerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
