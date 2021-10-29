using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program
{
    public class MM_StageSelect_System : MonoBehaviour
    {

        OR_SceneManager _SceneManager;

        //int
        [SerializeField] private int StageCount;            //�X�e�[�W��
        [SerializeField] private int CurrentSelectStage;    //���݂̃X�e�[�W

        //Text
        [SerializeField] private Text MaxScorePlayer;
        [SerializeField] private Text StageName;            //�X�e�[�W��
        [SerializeField] private Text StageDifficult;       //�X�e�[�W��Փx
        [SerializeField] private Text StageGimik;           //�X�e�[�W�M�~�b�N����
        [SerializeField] private Text CurrentMaxScore;

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
            if (CurrentSelectStage == 0) //�X�e�[�W1
            {
                _SceneManager.SceneName = "Stage_1";
                _SceneManager.NextSceneLoad();
            }
            if (CurrentSelectStage == 1) //�X�e�[�W2
            {
                _SceneManager.SceneName = "Stage_2";
                _SceneManager.NextSceneLoad();
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
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage1_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_Stage1_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>��</color><color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>��</color><color=#ffffff>��������</color>";
                            StageGimik.text = "��]�n";
                            break;
                        case 1: //�X�e�[�W2
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage2_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_Stage2_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>��</color><color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>����</color><color=#ffffff>������</color>";
                            StageGimik.text = "�g�Q�g�Q";
                            break;
                        case 2: //�X�e�[�W3
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage3_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_Stage3_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>�Q</color><color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>������</color><color=#ffffff>����</color>";
                            StageGimik.text = "�g�Q�g�Q";
                            break;
                        case 3: //�X�e�[�W4
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage4_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_Stage4_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>��</color><color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>��������</color><color=#ffffff>��</color>";
                            StageGimik.text = "�g�Q�g�Q";
                            break;
                        case 4: //�X�e�[�W5
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage5_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>��</color><color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#FF0000>����������</color>";
                            StageGimik.text = "�g�Q�g�Q";
                            break;
                        case 5: //�X�e�[�WEX
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.StageEx_MaxScores.ToString("0") + " �_";
                            MaxScorePlayer.text = "�L�^�ێ���: " + OR_SaveSystem.Instance.SaveData.RK_StageEx_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#ff00ff>���z</color> <color=#ffffff>�̊�</color>";
                            StageDifficult.text = "<color=#ffffff>��Փx:</color> <color=#6100FF>?????</color>";
                            StageGimik.text = "����J";
                            break;
                    }
                }
            }
        }
    }
}
