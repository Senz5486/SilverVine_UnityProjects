using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Senz_Program {
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
            OR_SaveSystem.Instance.Load();
            MixerSEGroup = GameObject.Find("SoundControllerObject").GetComponent<AudioSource>();
            MixerBGMGroup = GameObject.Find("MusicControllerObject").GetComponent<AudioSource>();
            MixerBGMGroup.volume = OR_SaveSystem.Instance.SaveData.BGMVolume;
            MixerBGMGroup.volume = OR_SaveSystem.Instance.SaveData.SEVolume;
            SEVolume.value = OR_SaveSystem.Instance.SaveData.SEVolume;
            BGMVolume.value = OR_SaveSystem.Instance.SaveData.BGMVolume;
        }

        void Update()
        {
            SEVolumeValue.text = (OR_SaveSystem.Instance.SaveData.SEVolume * 100).ToString("0") + "%";
            BGMVolumeValue.text = (OR_SaveSystem.Instance.SaveData.BGMVolume * 100).ToString("0") + "%";
        }
        public void SetSEVolume()
        {
            MixerSEGroup.volume = SEVolume.value;
            OR_SaveSystem.Instance.SaveData.SEVolume = SEVolume.value;
            OR_SaveSystem.Instance.Save();
        }
        public void SetBGMVolume()
        {
            MixerBGMGroup.volume = BGMVolume.value;
            OR_SaveSystem.Instance.SaveData.BGMVolume = BGMVolume.value;
            OR_SaveSystem.Instance.Save();
        }
    }
}
