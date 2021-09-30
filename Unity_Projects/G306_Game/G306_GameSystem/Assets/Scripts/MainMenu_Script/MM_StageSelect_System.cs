using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM_StageSelect_System : MonoBehaviour
{

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
                        StageDifficult.text = "��Փx: ����������";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 1: //�X�e�[�W2
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W2";
                        StageDifficult.text = "��Փx: ����������";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 2: //�X�e�[�W3
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W3";
                        StageDifficult.text = "��Փx: ����������";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 3: //�X�e�[�W4
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W4";
                        StageDifficult.text = "��Փx: ����������";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                    case 4: //�X�e�[�W5
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "�X�e�[�W5";
                        StageDifficult.text = "��Փx: ����������";
                        StageGimik.text = "�g�Q�g�Q";
                        break;
                }
            }
        }
    }
}
