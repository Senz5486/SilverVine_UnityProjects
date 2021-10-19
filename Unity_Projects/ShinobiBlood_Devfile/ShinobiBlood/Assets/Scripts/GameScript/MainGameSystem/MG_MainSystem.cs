using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program
{
    public class MG_MainSystem : MonoBehaviour
    {
        //���N���X�Q��
        MG_HealthSystem _HealthSystem;
        SoundController _SoundController;
        MusicController _MusicController;
        PlayerController _PlayerController;
        OR_SceneManager _SceneManager;
        MG_GoalSystem _GoalSystem;
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
            //_SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
            //_MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
            _SceneManager = GameObject.Find("ScriptObject").GetComponent<OR_SceneManager>();
            _PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            //_GoalSystem = GameObject.Find("GoalObject").GetComponent<MG_GoalSystem>();
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
            PlayStageMusic();
            isGameOver();
            isGameClear();
        }

        //�Q�[���I�[�o�[�V�X�e��
        void isGameOver()
        {
            if (_HealthSystem.isDead) //�v���C���[���Q�[���I�[�o�[����ɂȂ�����
            {
                GameOverUI.SetActive(true);
                GameOverCD.text = GameOverTime.ToString("0") + "�b";
                GameOverTime -= Time.deltaTime;
                if (GameOverTime <= 0)
                {
                    GameOverTime = 0;
                    _SceneManager.SceneName = "MainMenu";
                    _SceneManager.NextSceneLoad();
                }
            }
        }

        //�Q�[���N���A�V�X�e��
        void isGameClear() 
        {
            /*if (_GoalSystem.isGoalFlag)
            {
                _HealthSystem.isStart = false;
                _PlayerController.EnableCharaSystem = false;
                Invoke("DelayClearUI", 2.0f);
            }*/
        }

        //�Q�[���N���AUI��x�ꂳ���ďo��
        void DelayClearUI()
        {
            GameClearUI.SetActive(true);
            GameClearUISystem();
        }

        //�Q�[���N���AUI�̃V�X�e�� ->�X�R�A�v�Z�Ȃ�
        void GameClearUISystem()
        {

        }

        //�X�e�[�W���̉��y�̃V�X�e��
        void PlayStageMusic()
        {
            if (SceneManager.GetActiveScene().name == "Stage_1") //�X�e�[�W1�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Stage_2") //�X�e�[�W2�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Stage_3") //�X�e�[�W3�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Stage_4") //�X�e�[�W4�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Stage_5") //�X�e�[�W5�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Stage_Ex") //�X�e�[�WEx�̉��y
            {

            }
            else if (SceneManager.GetActiveScene().name == "Test") //Test�̉��y
            {

            }
        }

        //���C���Q�[���V�X�e��
        void MainGame()
        {
            if (_HealthSystem.isStart == false) //�Q�[�����J�n����O
            {
                if (CD_Timer > 1.0f)
                {
                    Stage_StartCountDown -= 1.0f;
                    CD_Timer = 0.0f;
                }
                else if (CD_Timer < 1.0f)
                {
                    CD_Timer += Time.deltaTime;
                }

                if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
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
            else if (_HealthSystem.isStart == true && StopMinusHealth == false)//�Q�[�����J�n������
            {
                _HealthSystem.MinusHealth = Stage_Minus; //�X�e�[�W���ƂɌ�������I�ׂ�
            }
        }

        //�J�E���g�_�E���e�L�X�g�폜�p
        void DeleteCDText()
        {
            CountDownText.text = "";
            _PlayerController.EnableCharaSystem = true;
            _HealthSystem.isStart = true;
        }
    }
}
