using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM_MainSystem : MonoBehaviour
{
    //SoundObject
    [SerializeField] private SoundController _SoundController;
    [SerializeField] private MusicController _MusicController;

    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        Invoke("PlayMusic", 0.1f);
    }
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void PlayMusic()
    {
    }
}
