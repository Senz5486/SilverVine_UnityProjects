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
        public int ResolutionSetting; //�𑜓x�p�̕ۑ�int
        public int Stage1_MaxScores;   //�X�R�A���ۑ�
        public int Stage2_MaxScores;   //�X�R�A���ۑ�
        public int Stage3_MaxScores;   //�X�R�A���ۑ�
        public int Stage4_MaxScores;   //�X�R�A���ۑ�
        public int Stage5_MaxScores;   //�X�R�A���ۑ�
        public int StageEx_MaxScores;   //�X�R�A���ۑ�
        //float
        public int ScreenWidth;   //�𑜓x�p�̕ۑ�float 
        public int ScreenHeight;  //�𑜓x�p�̕ۑ�float 
        public float SEVolume;      //�T�E���h�G�t�F�N�g�p�̕ۑ�float
        public float BGMVolume;     //BGM�p�̕ۑ�float
        //string
        public string PlayerName;   //�v���C���[���p�̕ۑ�String
        public string RK_Stage1_PlayerNames;   //�X�R�A���ۑ�
        public string RK_Stage2_PlayerNames;   //�X�R�A���ۑ�
        public string RK_Stage3_PlayerNames;   //�X�R�A���ۑ�
        public string RK_Stage4_PlayerNames;   //�X�R�A���ۑ�
        public string RK_Stage5_PlayerNames;   //�X�R�A���ۑ�
        public string RK_StageEx_PlayerNames;   //�X�R�A���ۑ�
        //bool
        public bool VSyncIsEnable;  //VSync�p�̕ۑ�bool
        public bool isFullScreen;   //�t���X�N���[���m�F�p�̕ۑ�bool
        public bool FinishTutorial; //�`���[�g���A�����I���Ă邩�m�F�p�̕ۑ�bool
        
    }
}
