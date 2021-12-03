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
        OR_SceneManager _SceneManager;
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
        [SerializeField] private GameObject TutorialGimmickLamp;
        [SerializeField] private GameObject TutorialGimmickBlock;
        [SerializeField] private GameObject invisibleBox;
        [SerializeField] private GameObject TutorialGoal;
        BoxCollider TutorialGimmikBlockCol;
        //bool
        bool isCanMove;
        bool UpdateOnce_Heal;
        bool UpdateOnce_Speed;
        bool UpdateOnce_Gimmick;
        public bool isGetHealItem;
        public bool isGetSpeedItem;
        private void Awake()
        {
            isGetHealItem = false;
            isGetSpeedItem = false;
            UpdateOnce_Heal = false;
            UpdateOnce_Speed = false;
            UpdateOnce_Gimmick = false;
            _MG_HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _MG_MainSystem = GameObject.Find("ScriptObject").GetComponent<MG_MainSystem>();
            _SceneManager = GameObject.Find("ScriptObject").GetComponent<OR_SceneManager>();
            ColObject[0].SetActive(true);
            _pc = GameObject.Find("Player").GetComponent<PlayerController>();
            _playerCamera = GameObject.Find("Player_Track_Camera").GetComponent<PlayerCamera>();
            _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
            _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
            TutorialGimmikBlockCol = GameObject.Find("ActiveBlock").GetComponent<BoxCollider>();
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
            if(TutorialGimmikBlockCol.enabled && !UpdateOnce_Gimmick)
            {
                Invoke("Tips15", 0.5f);
                invisibleBox.SetActive(false);
                UpdateOnce_Gimmick = true;
            }
            
        }

        void Tips1()
        {
            TutorialTipsText.text = "A,← キーで左移動 / D,→ キーで右移動 / スペース,↑ キー でジャンプ  /  Qキーでカメラの前後切り替え が出来ます";
            isCanMove = true;
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips2", 8.0f);
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
            Invoke("Tips6", 3.0f);
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
            Invoke("Tips9", 3.0f);
        }
        void Tips9()
        {
            isCanMove = false;
            TutorialTipsText.text = "次にギミックの説明です";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips10", 3.0f);
        }
        void Tips10()
        {
            _playerCamera.TargetObject = TutorialGimmickLamp.transform;
            TutorialTipsText.text = "灯篭の前でEキーを押すと魔法の詠唱が始まります";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips11", 4.0f);

        }
        void Tips11()
        {
            TutorialTipsText.text = "詠唱が終わると体力を消費し、魔法が発動します";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips12", 4.0f);
        }
        void Tips12()
        {
            TutorialTipsText.text = "詠唱は移動することでキャンセルが可能です";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips13", 4.0f);
        }
        void Tips13()
        {
            _playerCamera.TargetObject = TutorialGimmickBlock.transform;
            TutorialTipsText.text = "この場所では足場を作ることができます　試してください";
            _SoundController.PlaySEAudio = 7;
            invisibleBox.SetActive(true);
            Invoke("Tips14", 4.0f);
        }
        void Tips14()
        {
            TutorialTipsText.text = "";
            isCanMove = true;
            _playerCamera.TargetObject = Player.transform;
            ColObject[2].SetActive(false);
        }
        void Tips15()
        {
            isCanMove = false;
            TutorialTipsText.text = "ギミックには複数の種類があるので探してみてください";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips16", 3.0f);
        }
        void Tips16()
        {
            _playerCamera.TargetObject = TutorialGoal.transform;
            TutorialTipsText.text = "この場所がゴールです 到着するとクリアです";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips17", 3.0f);
        }
        void Tips17()
        {
            _playerCamera.TargetObject = Player.transform;
            TutorialTipsText.text = "本番ではさらに罠が設置されるので注意が必要です";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips18", 3.0f);
        }
        void Tips18()
        {
            TutorialTipsText.text = "さらに本編ではスコアもあるのでお楽しみください";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips19", 3.0f);
        }
        void Tips19()
        {
            TutorialTipsText.text = "メインメニューに戻ります　そのままお待ちください";
            _SoundController.PlaySEAudio = 7;
            Invoke("Tips20", 5.0f);
        }
        void Tips20()
        {
            TutorialTipsText.text = "";
            isCanMove = true;
            OR_SaveSystem.Instance.SaveData.FinishTutorial = true;
            OR_SaveSystem.Instance.Save();
            _SceneManager.SceneName = "MainMenu";
            _SceneManager.NextSceneLoad();
        }

    }
}
