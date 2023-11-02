using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mainMixer;

    public TMP_Text mastLabel, musicLabel, sfxLabel;

    public Slider mastSlider, musicSlider, sfxSlider;

    void Start()
    {
        float volume = 0f;
        mainMixer.GetFloat("MasterParam", out volume);
        mastSlider.value = volume;

        mainMixer.GetFloat("MusicParam", out volume);
        musicSlider.value = volume;
        
        mainMixer.GetFloat("SFXParam", out volume);
        sfxSlider.value = volume;


        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

    }

    public void setMasterVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();

        mainMixer.SetFloat("MasterParam", mastSlider.value);

        PlayerPrefs.SetFloat("MasterParam", mastSlider.value);
    }
    
    public void setMuiscVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        mainMixer.SetFloat("MusicParam", musicSlider.value);

        PlayerPrefs.SetFloat("MusicParam", musicSlider.value);
    }
    
    public void setSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        mainMixer.SetFloat("SFXParam", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXParam", sfxSlider.value);
    }

    public void Return()
    {
        SceneManager.LoadScene("AptScene");
    }
}
