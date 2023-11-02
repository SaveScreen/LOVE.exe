using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mainMixer;

    public TMP_Text masterLabel, musicLabel, sfxLabel;

    public Slider masterSlider, musicSlider, sfxSlider;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        masterLabel.text = masterSlider.value.ToString();
    }
}
