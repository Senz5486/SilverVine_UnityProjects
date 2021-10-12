using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        _playerCamera = GameObject.Find("ScriptObject").GetComponent<PlayerCamera>();
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Stage_Tutorial")
        {
            _MusicController.PlayBGMAudio = 5;
            TutorialUI.SetActive(true);
            TutorialTipsText.text = "�P����ւ悤����";
            isCanMove = false;
            Invoke("Tips1", 2.0f);
        }
    }

    private void Update()
    {
        _pc.EnableCharaSystem = isCanMove;
        if(isGetHealItem && !UpdateOnce_Heal)
        {
            Invoke("Tips5", 0.5f);
            UpdateOnce_Heal = true;
        }
        if(isGetSpeedItem && !UpdateOnce_Speed)
        {
            Invoke("Tips8", 0.5f);
            UpdateOnce_Speed = true;
        }
    }

    void Tips1()
    {
        TutorialTipsText.text = "A,�� �L�[�ō��ړ� / D,�� �L�[�ŉE�ړ� / �X�y�[�X,�� �L�[ �ŃW�����v ���o���܂�";
        isCanMove = true;
        Invoke("Tips2", 10.0f);
    }
    void Tips2()
    {
        isCanMove = false;
        _MG_HealthSystem.isStart = true;
        _MG_MainSystem.Stage_Minus = 1.42f;
        TutorialTipsText.text = "���̃Q�[���͖��b���ɑ̗͂�����܂��B ����ʂ̓X�e�[�W�ɂ���ĈႢ�܂� ���́w�̗́x�Q�[�W�����Ă݂܂��傤";
        Invoke("Tips3", 7.0f);
    }
    void Tips3()
    {
        isCanMove = false;
        _MG_HealthSystem.isStart = false;
        ColObject[0].SetActive(false);
        _playerCamera.TargetObject = TutorialHealItem.transform;
        TutorialTipsText.text = "�������ɂ���̂́A�񕜃A�C�e���ł� ����Ă݂܂��傤�B";
        Invoke("Tips4", 3.5f);
    }
    void Tips4()
    {
        isCanMove = true;
        _playerCamera.TargetObject = Player.transform;
        TutorialTipsText.text = "";
    }
    void Tips5()
    {
        isCanMove = false;
        TutorialTipsText.text = "�̗͂��񕜂��܂����� ���́w�̗́x�Q�[�W���m�F���܂��傤";
        Invoke("Tips6", 5.0f);
    }
    void Tips6()
    {
        _playerCamera.TargetObject = TutorialSpeedItem.transform;
        TutorialTipsText.text = "�������ɂ���̂́A���x�㏸�A�C�e���ł� ����Ă݂܂��傤";
        Invoke("Tips7", 3.5f);
    }
    void Tips7()
    {
        isCanMove = true;
        _playerCamera.TargetObject = Player.transform;
        TutorialTipsText.text = "";
    }
    void Tips8()
    {
        TutorialTipsText.text = "3�b�Ԃ̊ԑ��x���㏸���܂� �����Ă݂܂��傤";
        Invoke("Tips9", 5.0f);
    }
    void Tips9()
    {
        isCanMove = false;
        TutorialTipsText.text = "���ɂ��炭��̐������J�n���܂�";
    }
}
