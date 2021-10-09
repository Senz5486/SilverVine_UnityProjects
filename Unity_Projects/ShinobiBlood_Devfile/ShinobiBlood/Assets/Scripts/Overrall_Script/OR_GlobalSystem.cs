using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public struct SaveGlobalData
{
    //チュートリアル用
    public bool PlayTutorial;
    //ステージ最高スコア用
    public float Stage1_Rank1Score;
    public float Stage2_Rank1Score;
    public float Stage3_Rank1Score;
    public float Stage4_Rank1Score;
    public float Stage5_Rank1Score;
}
public class OR_GlobalSystem : MonoBehaviour
{
    const string SAVE_FILE_PATH = "SavePath.txt";

    MM_PushButtons PushButtons;
    private void Start()
    {
        PushButtons = GameObject.Find("ScriptObject").GetComponent<MM_PushButtons>();
    }

    public void Save_Json_Data()
    {
        //Save
        var savedata = new SaveGlobalData();
        savedata.PlayTutorial = PushButtons.isFirstPlay;
        savedata.Stage1_Rank1Score = 0.0f;
        savedata.Stage2_Rank1Score = 0.0f;
        savedata.Stage3_Rank1Score = 0.0f;
        savedata.Stage4_Rank1Score = 0.0f;
        savedata.Stage5_Rank1Score = 0.0f;

        var json = JsonUtility.ToJson(savedata);

        var DataPath = Application.dataPath + "/" + SAVE_FILE_PATH;
        var DataWriter = new StreamWriter(DataPath, false);

        DataWriter.WriteLine(json);
        DataWriter.Flush();
        DataWriter.Close();
    }

    public void Load_Json_Data()
    {
        //Load
        var savedata = new SaveGlobalData();
        var json = JsonUtility.ToJson(savedata);

        var DataInfo = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var DataReader = new StreamReader(DataInfo.OpenRead());
        var DataJson = DataReader.ReadToEnd();
        var LoadData = JsonUtility.FromJson<SaveGlobalData>(json);
    }
}
