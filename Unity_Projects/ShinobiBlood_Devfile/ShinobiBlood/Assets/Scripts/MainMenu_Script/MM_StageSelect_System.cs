using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM_StageSelect_System : MonoBehaviour
{

    OR_SceneManager _SceneManager;

    //int
    [SerializeField] private int StageCount;            //ステージ数
    [SerializeField] private int CurrentSelectStage;    //現在のステージ

    //Text
    [SerializeField] private Text StageName;            //ステージ名
    [SerializeField] private Text StageDifficult;       //ステージ難易度
    [SerializeField] private Text StageGimik;           //ステージギミック説明

    //GameObject
    [SerializeField] private GameObject[] StageImage;

    //bool 
    void Start()
    {
        _SceneManager = GameObject.Find("ScriptObject").GetComponent<OR_SceneManager>();
        CurrentSelectStage = 0;
        for (int i = 0; i <= StageCount; i++)
        {
            StageImage[i] = GameObject.Find("StageImage_" + i);
        }
    }

    void Update()
    {
        StageShownSystem();
    }
    public void StageLeftSelector() //セレクター左を押したとき
    {
        if (CurrentSelectStage == 0)
        {
            CurrentSelectStage = StageCount;
        }
        else if (CurrentSelectStage > 0)
        {
            CurrentSelectStage--;
        }
    }
    public void StageRightSelector() //セレクター右を押したとき
    {
        if (CurrentSelectStage == StageCount)
        {
            CurrentSelectStage = 0;
        }
        else if (CurrentSelectStage >= 0)
        {
            CurrentSelectStage++;
        }

    }
    
    public void PushGameStart()
    {
        if(CurrentSelectStage == 0) //ステージ1
        {
            _SceneManager.SceneName = "Stage_1";
            _SceneManager.NextSceneLoad();
        }
        if (CurrentSelectStage == 1) //ステージ2
        {

        }
        if (CurrentSelectStage == 2) //ステージ3
        {

        }
        if (CurrentSelectStage == 3) //ステージ4
        {

        }
        if (CurrentSelectStage == 4) //ステージ5
        {

        }
        if (CurrentSelectStage == 5) //ステージEX
        {

        }
    }
    void StageShownSystem() //現在のステージを表示する
    {
        //ステージ選択されたやつをステージ画像、ステージ名、難易度、詳細を表示するシステム
        for (int i = 0; i <= StageCount; i++)
        {
            
            StageImage[i].SetActive(false);
            if (i == CurrentSelectStage)
            {
                switch (CurrentSelectStage)
                {
                    case 0: //ステージ1
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ1";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★</color><color=#ffffff>☆☆☆☆</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 1: //ステージ2
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ2";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★</color><color=#ffffff>☆☆☆</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 2: //ステージ3
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ3";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★</color><color=#ffffff>☆☆</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 3: //ステージ4
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ4";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★★</color><color=#ffffff>☆</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 4: //ステージ5
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ5";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★★★</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 5: //ステージEX
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "<color=#470000>ステージ</color> <color=#C40065>EX</color>";
                        StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#6100FF>★★★★★</color>";
                        StageGimik.text = "トゲトゲ";
                        break;
                }
            }
        }
    }
}
