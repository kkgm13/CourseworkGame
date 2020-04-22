using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LaunchPlayerPrefs : MonoBehaviour
{
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("MasterVol")) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")) * 20);
        mixer.SetFloat("EffectVol", Mathf.Log10(PlayerPrefs.GetFloat("EffectVol")) * 20);
    }
}
