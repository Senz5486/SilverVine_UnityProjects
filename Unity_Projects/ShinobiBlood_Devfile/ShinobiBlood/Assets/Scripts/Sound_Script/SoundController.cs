using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }
    public int PlaySEAudio; //��������SE�̐��l������B��: audioClips��1�Ԃ߂𗬂������Ȃ�@PlaySEAudio��1�ɂ���B
    public AudioClip[] audioClips;
    AudioSource _audiosource;
    private void Awake()
    {
        PlaySEAudio = -1;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        _audiosource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlaySEAudio >= 0)
        {
            for (int i = 0; i <= PlaySEAudio; i++)
            {
                if (i == PlaySEAudio)
                { 
                    _audiosource.PlayOneShot(audioClips[i]);
                    PlaySEAudio = -1;
                    break;
                }
            }
        }
    }
}
