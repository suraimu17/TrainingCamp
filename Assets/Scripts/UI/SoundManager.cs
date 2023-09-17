using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField] AudioClip buttonSE;

    public AudioSource audioSource;
    static public float soundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = soundVolume;
    }

    public void PlaySE()
    {
        audioSource.PlayOneShot(buttonSE);
    }
}
