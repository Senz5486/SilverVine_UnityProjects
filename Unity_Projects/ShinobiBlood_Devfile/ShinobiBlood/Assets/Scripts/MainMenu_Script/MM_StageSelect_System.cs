using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program
{
    public class MM_StageSelect_System : MonoBehaviour
    {

        OR_SceneManager _SceneManager;

        //int
        [SerializeField] private int StageCount;            //ステージ数
        [SerializeField] private int CurrentSelectStage;    //現在のステージ

        //Text
        [SerializeField] private Text MaxScorePlayer;
        [SerializeField] private Text StageName;            //ステージ名
        [SerializeField] private Text StageDifficult;       //ステージ難易度
        [SerializeField] private Text StageGimik;           //ステージギミック説明
        [SerializeField] private Text CurrentMaxScore;

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
            if (CurrentSelectStage == 0) //ステージ1
            {
                _SceneManager.SceneName = "Stage_1";
                _SceneManager.NextSceneLoad();
            }
            if (CurrentSelectStage == 1) //ステージ2
            {
                _SceneManager.SceneName = "Stage_2";
                _SceneManager.NextSceneLoad();
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
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage1_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_Stage1_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>壱</color><color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★</color><color=#ffffff>☆☆☆☆</color>";
                            StageGimik.text = "回転刃";
                            break;
                        case 1: //ステージ2
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage2_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_Stage2_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>弐</color><color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★</color><color=#ffffff>☆☆☆</color>";
                            StageGimik.text = "トゲトゲ";
                            break;
                        case 2: //ステージ3
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage3_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_Stage3_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>参</color><color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★</color><color=#ffffff>☆☆</color>";
                            StageGimik.text = "トゲトゲ";
                            break;
                        case 3: //ステージ4
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage4_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_Stage4_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>肆</color><color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★★</color><color=#ffffff>☆</color>";
                            StageGimik.text = "トゲトゲ";
                            break;
                        case 4: //ステージ5
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.Stage5_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#FF0000>伍</color><color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#FF0000>★★★★★</color>";
                            StageGimik.text = "トゲトゲ";
                            break;
                        case 5: //ステージEX
                            CurrentMaxScore.text = OR_SaveSystem.Instance.SaveData.StageEx_MaxScores.ToString("0") + " 点";
                            MaxScorePlayer.text = "記録保持者: " + OR_SaveSystem.Instance.SaveData.RK_StageEx_PlayerNames;
                            StageImage[CurrentSelectStage].SetActive(true);
                            StageName.text = "<color=#ff00ff>超越</color> <color=#ffffff>の間</color>";
                            StageDifficult.text = "<color=#ffffff>難易度:</color> <color=#6100FF>?????</color>";
                            StageGimik.text = "非公開";
                            break;
                    }
                }
            }
        }
    }
}
