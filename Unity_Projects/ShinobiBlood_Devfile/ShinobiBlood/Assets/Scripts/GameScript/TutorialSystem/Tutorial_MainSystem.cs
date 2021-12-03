using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program
{
    public class Tutorial_MainSystem : MonoBehaviour
    {
        //Class
        MusicController _MusicController;
        SoundController _SoundController;
        PlayerController _pc;
        PlayerCamera _playerCamera;
        MG_HealthSystem _MG_HealthSystem;
        MG_MainSystem _MG_MainSystem;
        //Gameobject
        [SerializeField] private GameObject TutorialUI;
        [SerializeField] private GameObject[] CheckPoint;
        [SerializeField] private Text TutorialTipsText;

        [SerializeField] private GameObject[] ColObject;
        [SerializeField] private GameObject Player;
        [SerializeField] private GameObject TutorialHealItem;
        [SerializeField] private GameObject TutorialSpeedItem;
        //[SerializeField] private GameObject TutorialSpeedItem;
        //bool
        bool isCanMove;
        bool UpdateOnce_Heal;
        bool UpdateOnce_Speed;
        public bool isGetHealItem;
        public bool isGetSpeedItem;
        private void Awake()
        {
            isGetHealItem = false;
            isGetSpeedItem = false;
            UpdateOnce_Heal = false;
            UpdateOnce_Speed = false;
            _MG_HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _MG_MainSystem = GameObject.Find("ScriptObject").GetComponent<MG_MainSystem>();
            ColObject[0].SetActive(true);
            _pc = GameObject.Find("Player").GetComponent<PlayerController>();
            _playerCamera = GameObject.Find("Player_Track_Camera").GetComponent<PlayerCamera>();
            _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
            _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        }
        void Start()
        {
            if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
            {
                _MusicController.PlayBGMAudio = 5;
                TutorialUI.SetActive(true);
                TutorialTipsText.text = "訓練場へようこそ";
                isCanMove = false;
                Invoke("Tips1", 2.0f);
            }
        }

        private void Update()
        {
            _pc.EnableCharaSystem = isCanMove;
            if (isGetHealItem && !UpdateOnce_Heal)
            {
                Invoke("Tips5", 0.5f);
                UpdateOnce_Heal = true;
            }
            if (isGetSpeedItem && !UpdateOnce_Speed)
            {
                Invoke("Tips8", 0.5f);
                UpdateOnce_Speed = true;
            }
        }

        void Tips1()
        {
            TutorialTipsText.text = "A,← キーで左移動 / D,→ キーで右移動 / スペース,↑ キー でジャンプ が出来ます";
            isCanMove = true;
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips2", 10.0f);
        }
        void Tips2()
        {
            isCanMove = false;
            _MG_HealthSystem.isStart = true;
            _MG_MainSystem.Stage_Minus = 1.42f;
            TutorialTipsText.text = "下のゲージは『体力』　時と共に減少し、全て失うと倒れてしまいます";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips3", 7.0f);
        }
        void Tips3()
        {
            isCanMove = false;
            _MG_HealthSystem.isStart = false; 
            _playerCamera.TargetObject = TutorialHealItem.transform;
            TutorialTipsText.text = "これは『ZOK-2』  触れてみてください";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips4", 3.5f);
        }
        void Tips4()
        {
            isCanMove = true;
            ColObject[0].SetActive(false);
            _playerCamera.TargetObject = Player.transform;
            TutorialTipsText.text = "";
        }
        void Tips5()
        {
            isCanMove = false;
            TutorialTipsText.text = "『ZOK-2』は『体力』を回復させます";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips6", 5.0f);
        }
        void Tips6()
        {
            _playerCamera.TargetObject = TutorialSpeedItem.transform;
            TutorialTipsText.text = "次は『KSK-5』  触れてみてください";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips7", 3.5f);
        }
        void Tips7()
        {
            isCanMove = true;
            ColObject[1].SetActive(false);
            _playerCamera.TargetObject = Player.transform;
            TutorialTipsText.text = "";
        }
        void Tips8()
        {
            TutorialTipsText.text = "『KSK-5』は次にダメージを受けるまで速度を上昇させます";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips9", 5.0f);
        }
        void Tips9()
        {
            isCanMove = false;
            TutorialTipsText.text = "次にギミックの説明です";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips10", 2.0f);
        }
        void Tips10()
        {
            isCanMove = true;
            TutorialTipsText.text = "道なりに進んでください";
            _SoundController.PlaySEAudio = 7;

        }
    }
}
