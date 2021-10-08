using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial_MainSystem : MonoBehaviour
{
    //Class
    PlayerController _pc;
    PlayerCamera _playerCamera;
    MG_HealthSystem _MG_HealthSystem;
    //Gameobject
    [SerializeField] private GameObject TutorialUI;
    [SerializeField] private GameObject[] CheckPoint;
    [SerializeField] private Text TutorialTipsText;

    [SerializeField] private GameObject[] ColObject;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TutorialHealItem;
    //[SerializeField] private GameObject TutorialSpeedItem;
    //bool
    bool isCanMove;
    bool isGetHealItem;
    bool once;
    //float
    float StuckTime;
    float Timer;
    private void Awake()
    {
        _MG_HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        ColObject[0].SetActive(true);
        _pc = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerCamera = GameObject.Find("ScriptObject").GetComponent<PlayerCamera>();
    }
    void Start()
    {
        once = true;
        if(SceneManager.GetActiveScene().name == "Stage_Tutorial")
        {
            TutorialUI.SetActive(true);
            TutorialTipsText.text = "�P����ւ悤����";
            isCanMove = false;
            Invoke("Tips1", 2.0f);
        }
    }

    private void Update()
    {
        _pc.EnableCharaSystem = isCanMove;
        //if (TutorialHealItem.activeSelf == false && once == true)
        //{
        //    isGetHealItem = true;
        //}
        //if(isGetHealItem == true)
        //{
        //    Invoke("Tips5", 1.0f);
        //    isGetHealItem = false;
        //    once = false;
        //}
    }

    void Tips1()
    {
        TutorialTipsText.text = "A,�� �L�[�ō��ړ� / D,�� �L�[�ŉE�ړ� / �X�y�[�X,�� �L�[ �ŃW�����v ���o���܂�";
        isCanMove = true;
        Invoke("Tips2", 8.0f);
    }
    void Tips2()
    {
        isCanMove = false;
        _MG_HealthSystem.isStart = true;
        _MG_HealthSystem.MinusHealth = 2.0f;
        TutorialTipsText.text = "���̃Q�[���͖��b���ɑ̗͂�����܂��B ����ʂ̓X�e�[�W�ɂ���ĈႢ�܂� ���̗̑̓o�[�����Ă݂܂��傤";
        Invoke("Tips3", 15.0f);
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
        TutorialTipsText.text = "�̗͂��񕜂��܂����� ���̗̑̓o�[���m�F���܂��傤";
    }
}
