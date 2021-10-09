using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MG_MainSystem : MonoBehaviour
{
    //���N���X�Q��
    MG_HealthSystem _HealthSystem;
    SoundController _SoundController;
    MusicController _MusicController;
    PlayerController _PlayerController;
    //Gameobject
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject GameClearUI;
    //Text
    [SerializeField] private Text CountDownText;
    //float
    public float Stage_Minus;
    [SerializeField] private float Stage_StartCountDown;
    [SerializeField] private float CD_Timer;
    //bool
    public bool StopMinusHealth;
    //int
    private void Awake()
    {
        //_SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        //_MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        _PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        Invoke("PlayStageMusic", 0.1f);
    }
    void Start()
    {
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
        if (_HealthSystem.isDead) //�v���C���[���Q�[���I�[�o�[����ɂȂ�����
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

    void MainGame()
    {
        if (_HealthSystem.isStart == false) //�Q�[�����J�n����O
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
                switch (Stage_StartCountDown) //�X�e�[�W�J�n�J�E���g�_�E���\��
                {
                    case 0.0f:
                        Stage_StartCountDown = 0.0f;
                        CountDownText.text = "�Q�[���J�n...!";
                        Invoke("DeleteCDText", 0.5f);
                        break;
                    case 1.0f:
                        CountDownText.text = "�Q�[���J�n�܂� 1�b";
                        break;
                    case 2.0f:
                        CountDownText.text = "�Q�[���J�n�܂� 2�b";
                        break;
                    case 3.0f:
                        CountDownText.text = "�Q�[���J�n�܂� 3�b";
                        break;
                }
            }

        }
        else if(_HealthSystem.isStart == true && StopMinusHealth == false)//�Q�[�����J�n������
        {
            _HealthSystem.MinusHealth = Stage_Minus; //�X�e�[�W���ƂɌ�������I�ׂ�
        }
    }

    void DeleteCDText()
    {
        CountDownText.text = "";
        _PlayerController.EnableCharaSystem = true;
        _HealthSystem.isStart = true;

    }
}
