using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSet : SingletonMonoBehaviour<VolumeSet>
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.audioSource.volume = slider.value;
        SoundManager.soundVolume = slider.value;
    }
}
