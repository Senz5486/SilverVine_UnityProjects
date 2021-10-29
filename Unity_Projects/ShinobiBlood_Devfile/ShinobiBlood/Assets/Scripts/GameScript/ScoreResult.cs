using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program {
    public class ScoreResult : MonoBehaviour
    {
        Score_Mass MassScore;
        MG_MainSystem _MainSystem;
        [SerializeField] private Text StageName;
        [SerializeField] private Text ResultScoreText;
        [SerializeField] private Text CurrentStageMaxScoreText;
        [SerializeField] private Text ClearTimeText;
        [SerializeField] private Text UpdateStatusText;
        private float ShownTime;
        private bool UpdateMaxScore;
        void Start()
        {
            UpdateStatusText.text = "";
            UpdateMaxScore = false;
            if(SceneManager.GetActiveScene().name == "Stage_1")
            {
                StageName.text = "壱の間";
                CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage1_MaxScores.ToString();
            }
            if (SceneManager.GetActiveScene().name == "Stage_2")
            {
                StageName.text = "弐の間";
                CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage2_MaxScores.ToString();
            }
            MassScore = GameObject.Find("ScriptObject").GetComponent<Score_Mass>();
            _MainSystem = GameObject.Find("ScriptObject").GetComponent<MG_MainSystem>();
            ClearTimeText.text = "ステージクリアタイム:" + Random.Range(100, 999).ToString("0.00") +"秒";
            ShownTime = 3.0f;
        }

        private void Update()
        {
            ShownTime -= Time.deltaTime;
            if (ShownTime > 0)
            {
                ResultScoreText.text = Random.Range(100000, 999999).ToString("0");
                CurrentStageMaxScoreText.text = Random.Range(100000, 999999).ToString("0");
                ClearTimeText.text = "ステージクリアタイム:" + Random.Range(100, 999).ToString("0.00") + "秒";
            }
            else if (ShownTime < 0)
            {
                ResultScoreText.text = MassScore.Score().ToString();
                if(SceneManager.GetActiveScene().name == "Stage_1")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage1_MaxScores.ToString();
                }
                else if (SceneManager.GetActiveScene().name == "Stage_2")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage2_MaxScores.ToString();
                }
                else if (SceneManager.GetActiveScene().name == "Stage_3")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage3_MaxScores.ToString();
                }
                else if (SceneManager.GetActiveScene().name == "Stage_4")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage4_MaxScores.ToString();
                }
                else if (SceneManager.GetActiveScene().name == "Stage_5")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.Stage5_MaxScores.ToString();
                }
                else if (SceneManager.GetActiveScene().name == "Stage_Ex")
                {
                    CurrentStageMaxScoreText.text = OR_SaveSystem.Instance.SaveData.StageEx_MaxScores.ToString();
                }
                SaveMaxScore();
                ClearTimeText.text = "ステージクリアタイム:" + _MainSystem.Stage_ProgressTime.ToString("0.00") + "秒";
                ShownTime = -1;
            }
        }

         private void SaveMaxScore()
        {
            if (SceneManager.GetActiveScene().name == "Stage_1")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage1_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.Stage1_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage1_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_2")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage2_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.Stage2_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage2_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_3")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage3_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.Stage3_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage3_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_4")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage4_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.Stage4_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage4_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_5")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage5_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.Stage5_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_Ex")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.StageEx_MaxScores)
                {
                    UpdateMaxScore = true;
                    UpdateStatusText.text = "ステージ最大スコアを更新!";
                    OR_SaveSystem.Instance.SaveData.StageEx_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_StageEx_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                    OR_SaveSystem.Instance.Save();
                    if (UpdateMaxScore)
                    {
                        Invoke("DeleteUpdateMaxScoreText", 2.5f);
                        UpdateMaxScore = false;
                    }
                }
            }
        }
        void DeleteUpdateMaxScoreText()
        {
            UpdateStatusText.text = "";
        }
    }
}
