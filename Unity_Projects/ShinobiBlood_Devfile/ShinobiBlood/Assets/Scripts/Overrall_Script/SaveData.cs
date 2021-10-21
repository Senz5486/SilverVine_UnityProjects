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
        public int ScreenWidth;   //解像度用の保存float 
        public int ScreenHeight;  //解像度用の保存float 
        public float SEVolume;      //サウンドエフェクト用の保存float
        public float BGMVolume;     //BGM用の保存float
        //string
        public string PlayerName;   //プレイヤー名用の保存String
        //bool
        public bool VSyncIsEnable;  //VSync用の保存bool
        public bool isFullScreen;   //フルスクリーン確認用の保存bool
        public bool FinishTutorial; //チュートリアルを終えてるか確認用の保存bool
    }
}
