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
        public int QualitySetting = 2;     //品質設定保存
        public int Stage1_MaxScores = 0;   //スコア仮保存
        public int Stage2_MaxScores = 0;   //スコア仮保存
        public int Stage3_MaxScores = 0;   //スコア仮保存
        public int Stage4_MaxScores = 0;   //スコア仮保存
        public int Stage5_MaxScores = 0;   //スコア仮保存
        public int StageEx_MaxScores = 0;   //スコア仮保存

        //float
        public int ScreenWidth = 1920;   //解像度用の保存float 
        public int ScreenHeight = 1080;  //解像度用の保存float 
        public float SEVolume = 0.4f;      //サウンドエフェクト用の保存float
        public float BGMVolume = 0.5f;     //BGM用の保存float
        //string
        public string PlayerName = "名前無し 登録してください";   //プレイヤー名用の保存String
        public string RK_Stage1_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        public string RK_Stage2_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        public string RK_Stage3_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        public string RK_Stage4_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        public string RK_Stage5_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        public string RK_StageEx_PlayerNames = "現在最高記録がありません";   //スコア仮保存
        //bool
        public bool VSyncIsEnable = true;  //VSync用の保存bool
        public bool isFullScreen = true;   //フルスクリーン確認用の保存bool
        public bool FinishTutorial = false; //チュートリアルを終えてるか確認用の保存bool
        
    }
}
