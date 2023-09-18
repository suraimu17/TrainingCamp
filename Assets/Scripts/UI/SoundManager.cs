using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField] private List<AudioData> audioDataList;

    public AudioSource audioSource { get; private set; }
    static public float soundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = soundVolume;
    }

    public void PlaySE(AudioType type)
    {
        AudioClip audioClip = FindAudioClip(type);
        audioSource.PlayOneShot(audioClip);
    }

    private AudioClip FindAudioClip(AudioType type)
    {
        var data = audioDataList.Find(x => x.Type == type);
        if(data is null)
        {
            throw new Exception($"Audio data is null. (type: {type})");
        }

        if(data.Clip is null)
        {
            throw new Exception($"Audio clip is null. (type: {type})");
        }

        return data.Clip;
    }
}
