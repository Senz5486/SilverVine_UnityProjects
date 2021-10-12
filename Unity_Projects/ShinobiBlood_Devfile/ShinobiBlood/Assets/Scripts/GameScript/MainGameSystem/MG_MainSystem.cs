using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MG_MainSystem : MonoBehaviour
{
    //他クラス参照
    MG_HealthSystem _HealthSystem;
    SoundController _SoundController;
    MusicController _MusicController;
    PlayerController _PlayerController;
    OR_SceneManager _SceneManager;
    //Gameobject
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject GameClearUI;
    //Text
    [SerializeField] private Text CountDownText;
    [SerializeField] private Text GameOverCD;
    //float
    public float Stage_Minus;
    [SerializeField] private float Stage_StartCountDown;
    [SerializeField] private float CD_Timer;
    private float GameOverTime;
    //bool
    public bool StopMinusHealth;
    //int
    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        _SceneManager = GameObject.Find("ScriptObject").GetComponent<OR_SceneManager>();
        _PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        Invoke("PlayStageMusic", 0.1f);
    }
    void Start()
    {
        GameOverTime = 30.0f;
        GameOverUI.SetActive(false);
        GameClearUI.SetActive(false);
        _PlayerController.EnableCharaSystem = false;
    }

    void Update()
    {
        MainGame();
        isGameOver();
    }

    void isGameOver()
    {
        if (_HealthSystem.isDead) //プレイヤーがゲームオーバー判定になったら
        {
            GameOverUI.SetActive(true);
            GameOverCD.text = GameOverTime.ToString("0") + "秒";
            GameOverTime -= Time.deltaTime;
            if(GameOverTime <= 0)
            {
                GameOverTime = 0;
                _SceneManager.SceneName = "MainMenu";
                _SceneManager.NextSceneLoad();
            }
        }
    }

    void isGameClear()
    {

    }

    void PlayStageMusic()
    {

    }

    void MainGame()
    {
        if (_HealthSystem.isStart == false) //ゲームが開始する前
        {
            if(CD_Timer > 1.0f)
            {
                Stage_StartCountDown -= 1.0f;
                CD_Timer = 0.0f;
            }
            else if(CD_Timer < 1.0f)
            {
                CD_Timer += Time.deltaTime;
            }

            if(SceneManager.GetActiveScene().name == "Stage_Tutorial")
            {
                CountDownText.text = "";
            }
            else
            {
                switch (Stage_StartCountDown) //ステージ開始カウントダウン表示
                {
                    case 0.0f:
                        Stage_StartCountDown = 0.0f;
                        CountDownText.text = "ゲーム開始...!";
                        Invoke("DeleteCDText", 0.5f);
                        break;
                    case 1.0f:
                        CountDownText.text = "ゲーム開始まで 1秒";
                        break;
                    case 2.0f:
                        CountDownText.text = "ゲーム開始まで 2秒";
                        break;
                    case 3.0f:
                        CountDownText.text = "ゲーム開始まで 3秒";
                        break;
                }
            }

        }
        else if(_HealthSystem.isStart == true && StopMinusHealth == false)//ゲームが開始したら
        {
            _HealthSystem.MinusHealth = Stage_Minus; //ステージごとに減少率を選べる
        }
    }

    void DeleteCDText()
    {
        CountDownText.text = "";
        _PlayerController.EnableCharaSystem = true;
        _HealthSystem.isStart = true;
    }
}
