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
        public int ResolutionSetting;
        //float
        public int ScreenWidth;   //�𑜓x�p�̕ۑ�float 
        public int ScreenHeight;  //�𑜓x�p�̕ۑ�float 
        public float SEVolume;      //�T�E���h�G�t�F�N�g�p�̕ۑ�float
        public float BGMVolume;     //BGM�p�̕ۑ�float
        //string
        public string PlayerName;   //�v���C���[���p�̕ۑ�String
        //bool
        public bool VSyncIsEnable;  //VSync�p�̕ۑ�bool
        public bool isFullScreen;   //�t���X�N���[���m�F�p�̕ۑ�bool
        public bool FinishTutorial; //�`���[�g���A�����I���Ă邩�m�F�p�̕ۑ�bool
    }
}
