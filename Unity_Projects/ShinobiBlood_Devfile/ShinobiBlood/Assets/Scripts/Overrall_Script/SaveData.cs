using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Senz_Program
{
    [System.Serializable]
    public class SaveData
    {
        //int
        public int QualitySetting = 2;     //�i���ݒ�ۑ�
        public int Stage1_MaxScores = 0;   //�X�R�A���ۑ�
        public int Stage2_MaxScores = 0;   //�X�R�A���ۑ�
        public int Stage3_MaxScores = 0;   //�X�R�A���ۑ�
        public int Stage4_MaxScores = 0;   //�X�R�A���ۑ�
        public int Stage5_MaxScores = 0;   //�X�R�A���ۑ�
        public int StageEx_MaxScores = 0;   //�X�R�A���ۑ�

        //float
        public int ScreenWidth = 1920;   //�𑜓x�p�̕ۑ�float 
        public int ScreenHeight = 1080;  //�𑜓x�p�̕ۑ�float 
        public float SEVolume = 0.4f;      //�T�E���h�G�t�F�N�g�p�̕ۑ�float
        public float BGMVolume = 0.5f;     //BGM�p�̕ۑ�float
        //string
        public string PlayerName = "���O���� �o�^���Ă�������";   //�v���C���[���p�̕ۑ�String
        public string RK_Stage1_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        public string RK_Stage2_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        public string RK_Stage3_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        public string RK_Stage4_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        public string RK_Stage5_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        public string RK_StageEx_PlayerNames = "���ݍō��L�^������܂���";   //�X�R�A���ۑ�
        //bool
        public bool VSyncIsEnable = true;  //VSync�p�̕ۑ�bool
        public bool isFullScreen = true;   //�t���X�N���[���m�F�p�̕ۑ�bool
        public bool FinishTutorial = false; //�`���[�g���A�����I���Ă邩�m�F�p�̕ۑ�bool
        
    }
}
