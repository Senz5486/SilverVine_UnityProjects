using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_MainSystem : MonoBehaviour
{
    //他クラス参照
    MG_HealthSystem _HealthSystem;
    SoundController _SoundController;
    MusicController _MusicController;
    //Gameobject
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject GameClearUI;
    //Text

    //float

    //bool

    //int
    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        Invoke("PlayStageMusic", 0.1f);
    }
    void Start()
    {
        GameOverUI.SetActive(false);
        GameClearUI.SetActive(false);
    }


    void Update()
    {

    }

    void isGameOver()
    {
        if (_HealthSystem.isDead) //プレイヤーがゲームオーバー判定になったら
        {
            GameOverUI.SetActive(true);
            
        }
    }

    void isGameClear()
    {

    }

    void PlayStageMusic()
    {

    }
}
