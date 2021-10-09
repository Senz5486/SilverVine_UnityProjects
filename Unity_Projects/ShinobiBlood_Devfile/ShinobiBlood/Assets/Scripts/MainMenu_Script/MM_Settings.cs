using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MM_Settings : MonoBehaviour
{
    //Slider
    [SerializeField] private Slider MasterVolume;
    [SerializeField] private Slider SEVolume;
    [SerializeField] private Slider BGMVolume;
    //AudioMixer
    [SerializeField] private AudioSource MixerSEGroup;
    [SerializeField] private AudioSource MixerBGMGroup;
    //Text
    [SerializeField] private Text MasterVolumeValue;
    [SerializeField] private Text SEVolumeValue;
    [SerializeField] private Text BGMVolumeValue;
    void Start()
    {
        MixerSEGroup = GameObject.Find("SoundControllerObject").GetComponent<AudioSource>();
        MixerBGMGroup = GameObject.Find("MusicControllerObject").GetComponent<AudioSource>();
    }

    void Update()
    {
        SEVolumeValue.text = (SEVolume.value * 100).ToString("0") + "%";
        BGMVolumeValue.text = (BGMVolume.value * 100).ToString("0") + "%";
    }
    public void SetSEVolume()
    {
        MixerSEGroup.volume = SEVolume.value;
    }
    public void SetBGMVolume()
    {
        MixerBGMGroup.volume = BGMVolume.value;
    }
}
