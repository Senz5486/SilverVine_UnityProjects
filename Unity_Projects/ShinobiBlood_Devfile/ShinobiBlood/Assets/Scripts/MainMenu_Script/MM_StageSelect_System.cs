using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM_StageSelect_System : MonoBehaviour
{

    OR_SceneManager _SceneManager;

    //int
    [SerializeField] private int StageCount;            //�X�e�[�W��
    [SerializeField] private int CurrentSelectStage;    //���݂̃X�e�[�W

    //Text
    [SerializeField] private Text StageName;            //�X�e�[�W��
    [SerializeField] private Text StageDifficult;       //�X�e�[�W��Փx
    [SerializeField] private Text StageGimik;           //�X�e�[�W�M�~�b�N����

    //GameObject
    [SerializeField] private GameObject[] StageImage;

    //bool 
    void Start()
    {
        _SceneManager = GameObject.Find("ScriptObject").GetComponent<OR_SceneManager>();
        CurrentSelectStage = 0;
        for (int i = 0; i <= StageCount; i++)
        {
            StageImage[i] = GameObject.Find("StageImage_" + i);
        }
    }

    void Update()
    {
        StageShownSystem();
    }
    public void StageLeftSelector() //�Z���N�^�[�����������Ƃ�
    {
        if (CurrentSelectStage == 0)
        {
            CurrentSelectStage = StageCount;
        }
        else if (CurrentSelectStage > 0)
        {
            CurrentSelectStage--;
        }
    }
    public void StageRightSelector() //�Z���N�^�[�E���������Ƃ�
    {
        if (CurrentSelectStage == StageCount)
        {
            CurrentSelectStage = 0;
        }
        else if (CurrentSelectStage >= 0)
        {
            CurrentSelectStage++;
        }

    }
    
    public void PushGameStart()
    {
        if(CurrentSelectStage == 0) //�X�e�[�W1
        {
            _SceneManager.SceneName = "Stage_1";
            _SceneManager.NextSceneLoad();
        }
        if (CurrentSelectStage == 1) //�X�e�[�W2
        {

        }
        if (CurrentSelectStage == 2) //�X�e�[�W3
        {

        }
        if (CurrentSelectStage == 3) //�X�e�[�W4
        {

        }
        if (CurrentSelectStage == 4) //�X�e�[�W5
        {

        }
        if (CurrentSelectStage == 5) //�X�e�[�WEX
        {

        }
    }
    void StageShownSystem() //���݂̃X�e�[�W��\������
    {
        //�X�e�[�W�I�����ꂽ����X�e�[�W�摜�A�X�e�[�W���A��Փx�A�ڍׂ�\������V�X�e��
        for (int i = 0; i <= StageCount; i++)
        {
            
            StageImage[i].SetActive(false);
            if (i == CurrentSelectStage)
            {
                switch (CurrentSelectStage)
                {
                    case 0: //�X�e�[�W1
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W1";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>��</color><color=#ffffff>��������</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 1: //�X�e�[�W2
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W2";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>����</color><color=#ffffff>������</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 2: //�X�e�[�W3
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W3";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>������</color><color=#ffffff>����</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 3: //�X�e�[�W4
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W4";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>��������</color><color=#ffffff>��</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 4: //�X�e�[�W5
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W5";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>����������</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 5: //�X�e�[�WEX
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "<color=#470000>�X�e�[�W</color> <color=#C40065>EX</color>";
                        StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#6100FF>����������</color>";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                }
            }
        }
    }
}
