using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public int PlayBGMAudio; //��������SE�̐��l������B��: audioClips��1�Ԃ߂𗬂������Ȃ�@PlaySEAudio��1�ɂ���B
    public int LastPlayMusicNo;
    public AudioClip[] audioClips;
    AudioSource _audiosource;
    bool isPlayingStart;
    private void Awake()
    {
        LastPlayMusicNo = -1;
    }
    void Start()
    {
        _audiosource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_audiosource.isPlaying && isPlayingStart == true)
        {
            _audiosource.PlayOneShot(audioClips[LastPlayMusicNo]);
        }
        if (audioClips.Length <= PlayBGMAudio)
        {
            PlayBGMAudio = -1;
        }
        if (PlayBGMAudio >= 0)
        {
            for (int i = 0; i <= PlayBGMAudio; i++)
            {
                if (_audiosource.isPlaying)
                {
                    _audiosource.Stop();
                }
                if (i == PlayBGMAudio)
                {
                    isPlayingStart = true;
                    LastPlayMusicNo = PlayBGMAudio;
                    _audiosource.PlayOneShot(audioClips[i]);
                    PlayBGMAudio = -1;
                    break;
                }
            }
        }
    }
}
