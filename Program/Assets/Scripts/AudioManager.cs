using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
     public static AudioManager instance;

     public AudioMixer mixer;

     public const string BGM_KEY = "bgmVolume";
     public const string SFX_KEY = "sfxVolume";

     void Awake()
     {
          if (instance == null)
          {
               instance = this;
               DontDestroyOnLoad(gameObject);
          }
          else
          {
               Destroy(gameObject);
          }
     }

     void Start()
     {
          LoadVolume();
     }

     void LoadVolume()
     {
          // Default sound : Max(1f)
          float bgmVolume = PlayerPrefs.GetFloat(BGM_KEY, 1f);
          float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

          mixer.SetFloat(VolumeSettings.MIXER_BGM, Mathf.Log10(bgmVolume) * 20);
          mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
     }
}
