using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public int PlayBGMAudio; //流したいSEの数値を入れる。例: audioClipsの1番めを流したいなら　PlaySEAudioを1にする。
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
