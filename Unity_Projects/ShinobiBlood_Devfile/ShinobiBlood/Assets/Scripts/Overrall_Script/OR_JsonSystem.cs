using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Save_Data
{
    public bool FinishTutorial;
}

public class OR_JsonSystem : MonoBehaviour
{
    Save_Data save = new Save_Data();
    public string FilePath;
    private void Awake()
    {
       FilePath = Application.dataPath + "/Save_Data.json";
    }

    public void SaveSystem()
    {
        string jsonstr = JsonUtility.ToJson(save);
        StreamWriter writer = new StreamWriter(FilePath, false);
        writer.WriteLine(jsonstr);
        writer.Flush();
        writer.Close();
    }
    public Save_Data LoadSystem(string dataPath)
    {
        StreamReader reader = new StreamReader(dataPath);
        string datastr = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<Save_Data>(datastr);
    }
}
