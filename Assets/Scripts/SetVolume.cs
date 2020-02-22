using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixerName;

    public void SetLevel(float sliderVal){
        mixer.SetFloat(mixerName,
        Mathf.Log10(sliderVal) * 20 // Slider Value respresented by the Log base of 10 & multiply by 20
        );
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
