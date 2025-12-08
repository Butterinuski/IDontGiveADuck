using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum SoundType
{
   GoodDucks,
   BadDucks,
   ClickSound,
   WaterParticle,
   LowTimer
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [Header("SoundList")]
    [SerializeField] private SoundList[] soundlist;

    [Header("Referneces")]
    private static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField] Slider volumeSlider;

    public AudioSource sfxSource;        
    public AudioSource lowTimerSource;

    //public Slider VolumeSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("soundVolume"))
            LoadVolume();
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadVolume();
        }


    }
    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
        SaveVolume();
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public static void PlaySound(SoundType Sound, float volume = 1)
    {
        AudioClip[] clips = instance.soundlist[(int)Sound].sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }




#if UNITY_EDITOR
    private void OnEnable()
    {
        String[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundlist, names.Length);
        for (int i = 0; i < soundlist.Length; i++)
        {
            soundlist[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] sounds { get => Sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] Sounds;
}
