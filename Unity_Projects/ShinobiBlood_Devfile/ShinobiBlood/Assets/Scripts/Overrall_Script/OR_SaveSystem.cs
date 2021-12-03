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

        public string FilePath => Application.dataPath + "/data.sav";
        
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
                Debug.Log("ƒtƒ@ƒCƒ‹‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
                SaveData = new SaveData();
                Save();
                return;
            }

            StreamReader reader = new StreamReader(FilePath);
            string jsonData = reader.ReadToEnd();
            SaveData = JsonUtility.FromJson<SaveData>(jsonData);
            reader.Close();

        }
    }

}
