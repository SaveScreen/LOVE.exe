using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("MasterParam"))
        {
            mainMixer.SetFloat("MasterParam", PlayerPrefs.GetFloat("MasterParam"));
        }
        if(PlayerPrefs.HasKey("VolumeParam"))
        {
            mainMixer.SetFloat("VolumeParam", PlayerPrefs.GetFloat("VolumeParam"));
        }
        if(PlayerPrefs.HasKey("SFXParam"))
        {
            mainMixer.SetFloat("SFXParam", PlayerPrefs.GetFloat("SFXParam"));
        }

    }
}
