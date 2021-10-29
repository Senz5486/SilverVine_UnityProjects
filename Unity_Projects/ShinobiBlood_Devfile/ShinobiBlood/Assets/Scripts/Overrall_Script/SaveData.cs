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
        public int ResolutionSetting; //解像度用の保存int
        public int Stage1_MaxScores;   //スコア仮保存
        public int Stage2_MaxScores;   //スコア仮保存
        public int Stage3_MaxScores;   //スコア仮保存
        public int Stage4_MaxScores;   //スコア仮保存
        public int Stage5_MaxScores;   //スコア仮保存
        public int StageEx_MaxScores;   //スコア仮保存
        //float
        public int ScreenWidth;   //解像度用の保存float 
        public int ScreenHeight;  //解像度用の保存float 
        public float SEVolume;      //サウンドエフェクト用の保存float
        public float BGMVolume;     //BGM用の保存float
        //string
        public string PlayerName;   //プレイヤー名用の保存String
        public string RK_Stage1_PlayerNames;   //スコア仮保存
        public string RK_Stage2_PlayerNames;   //スコア仮保存
        public string RK_Stage3_PlayerNames;   //スコア仮保存
        public string RK_Stage4_PlayerNames;   //スコア仮保存
        public string RK_Stage5_PlayerNames;   //スコア仮保存
        public string RK_StageEx_PlayerNames;   //スコア仮保存
        //bool
        public bool VSyncIsEnable;  //VSync用の保存bool
        public bool isFullScreen;   //フルスクリーン確認用の保存bool
        public bool FinishTutorial; //チュートリアルを終えてるか確認用の保存bool
        
    }
}
