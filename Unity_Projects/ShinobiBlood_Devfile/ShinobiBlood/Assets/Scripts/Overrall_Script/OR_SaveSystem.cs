using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Senz_Program
{
    public class OR_SaveSystem
    {
        private static OR_SaveSystem instance = new OR_SaveSystem();
        public static OR_SaveSystem Instance => instance;

        private OR_SaveSystem() { Load(); }

        public string FilePath => Application.dataPath + "/data.json";
        
        public SaveData SaveData { get; private set; }

        public void Save()
        {
            string jsonData = JsonUtility.ToJson(SaveData);
            StreamWriter writer = new StreamWriter(FilePath, false);
            writer.WriteLine(jsonData);
            writer.Flush();
            writer.Close();
        }

        public void Load()
        {
            if (!File.Exists(FilePath))
            {
                Debug.Log("ファイルが見つかりません");
                SaveData = new SaveData();
                Save();
                //初期値
                Instance.SaveData.Stage1_MaxScores = 0;
                Instance.SaveData.Stage2_MaxScores = 0;
                Instance.SaveData.Stage3_MaxScores = 0;
                Instance.SaveData.Stage4_MaxScores = 0;
                Instance.SaveData.Stage5_MaxScores = 0;
                Instance.SaveData.StageEx_MaxScores = 0;

                Instance.SaveData.RK_Stage1_PlayerNames = "現在最高記録がありません";
                Instance.SaveData.RK_Stage2_PlayerNames = "現在最高記録がありません";
                Instance.SaveData.RK_Stage3_PlayerNames = "現在最高記録がありません";
                Instance.SaveData.RK_Stage4_PlayerNames = "現在最高記録がありません";
                Instance.SaveData.RK_Stage5_PlayerNames = "現在最高記録がありません";
                Instance.SaveData.RK_StageEx_PlayerNames = "現在最高記録がありません";

                Instance.SaveData.PlayerName = "名前無し 登録してください";

                Instance.SaveData.SEVolume = 0.5f;
                Instance.SaveData.BGMVolume = 0.4f;

                Instance.SaveData.isFullScreen = true;
                Instance.SaveData.ScreenWidth = 1920;
                Instance.SaveData.ScreenHeight = 1080;
                Instance.SaveData.ResolutionSetting = 5;
                Instance.SaveData.VSyncIsEnable = true;
                return;
            }

            StreamReader reader = new StreamReader(FilePath);
            string jsonData = reader.ReadToEnd();
            SaveData = JsonUtility.FromJson<SaveData>(jsonData);
            reader.Close();

        }
    }

}
