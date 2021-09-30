using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM_StageSelect_System : MonoBehaviour
{

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
                        StageDifficult.text = "難易度: ★☆☆☆☆";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 1: //ステージ2
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ2";
                        StageDifficult.text = "難易度: ★☆☆☆☆";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 2: //ステージ3
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ3";
                        StageDifficult.text = "難易度: ★☆☆☆☆";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 3: //ステージ4
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ4";
                        StageDifficult.text = "難易度: ★☆☆☆☆";
                        StageGimik.text = "トゲトゲ";
                        break;
                    case 4: //ステージ5
                        StageImage[CurrentSelectStage].SetActive(true);
                        StageName.text = "ステージ5";
                        StageDifficult.text = "難易度: ★☆☆☆☆";
                        StageGimik.text = "トゲトゲ";
                        break;
                }
            }
        }
    }
}
