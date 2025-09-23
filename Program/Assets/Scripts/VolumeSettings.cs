using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
     public AudioMixer mixer;
     public Slider bgmSlider;
     public Slider sfxSlider;

     public const string MIXER_BGM = "BgmVolume";
     public const string MIXER_SFX = "SFXVolume";

     void Awake()
     {
          bgmSlider.onValueChanged.AddListener(SetBgmVolume);
          sfxSlider.onValueChanged.AddListener(SetSFXVolume);
     }

     void Start()
     {
          // setting value in slider
          // if PlayerPrefs.GetFloat fail, value = 1f;
          bgmSlider.value = PlayerPrefs.GetFloat(AudioManager.BGM_KEY, 1f);
          sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
     }

     void OnDisable()
     {
          // when program exit, save existed value
          PlayerPrefs.SetFloat(AudioManager.BGM_KEY, bgmSlider.value);
          PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
     }

     void SetBgmVolume(float value)
     {
          // slider's value range (0 ~ 1), audio mixer's value range(-80 ~ 20)
          mixer.SetFloat(MIXER_BGM, Mathf.Log10(value) * 20);
     }

     void SetSFXVolume(float value)
     {
          mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
     }
}
