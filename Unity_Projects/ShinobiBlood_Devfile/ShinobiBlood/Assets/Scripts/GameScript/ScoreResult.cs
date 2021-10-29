using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program {
    public class ScoreResult : MonoBehaviour
    {
        Score_Mass MassScore;
        [SerializeField] private Text ResultScoreText;
        [SerializeField] private Text CurrentStageMaxScoreText;
        private float ShownTime;
        void Start()
        {
            MassScore = GameObject.Find("ScriptObject").GetComponent<Score_Mass>();
            ShownTime = 3.0f;
        }

        private void Update()
        {
            ShownTime -= Time.deltaTime;
            if (ShownTime > 0)
            {
                ResultScoreText.text = Random.Range(100000, 999999).ToString("0");
            }
            else if (ShownTime < 0)
            {
                ResultScoreText.text = MassScore.Score().ToString();
                SaveMaxScore();
                ShownTime = -1;
            }
        }

         private void SaveMaxScore()
        {
            if(SceneManager.GetActiveScene().name == "Stage_1")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage1_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.Stage1_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage1_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_2")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage2_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.Stage2_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage2_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_3")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage3_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.Stage3_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage3_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_4")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage4_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.Stage4_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage4_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_5")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.Stage5_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.Stage5_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Stage_Ex")
            {
                if (MassScore.Score() > OR_SaveSystem.Instance.SaveData.StageEx_MaxScores)
                {
                    OR_SaveSystem.Instance.SaveData.StageEx_MaxScores = MassScore.Score();
                    OR_SaveSystem.Instance.SaveData.RK_StageEx_PlayerNames = OR_SaveSystem.Instance.SaveData.PlayerName;
                }
            }
        }
    }
}
