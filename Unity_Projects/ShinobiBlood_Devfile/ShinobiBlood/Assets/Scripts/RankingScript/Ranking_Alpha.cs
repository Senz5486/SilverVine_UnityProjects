using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program
{
    public class Ranking_Alpha : MonoBehaviour
    {
        [SerializeField] private Text[] PlayerNames;
        [SerializeField] private Text[] Stage_MaxScores;
        private void Awake()
        {
            OR_SaveSystem.Instance.Load();
        }
        private void Update()
        {
            for(int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        PlayerNames[0].text = OR_SaveSystem.Instance.SaveData.RK_Stage1_PlayerNames;
                        Stage_MaxScores[0].text = OR_SaveSystem.Instance.SaveData.Stage1_MaxScores.ToString() + " 点";
                        break;
                    case 1:
                        PlayerNames[1].text = OR_SaveSystem.Instance.SaveData.RK_Stage2_PlayerNames;
                        Stage_MaxScores[1].text = OR_SaveSystem.Instance.SaveData.Stage2_MaxScores.ToString() + " 点";
                        break;
                    case 2:
                        PlayerNames[2].text = OR_SaveSystem.Instance.SaveData.RK_Stage3_PlayerNames;
                        Stage_MaxScores[2].text = OR_SaveSystem.Instance.SaveData.Stage3_MaxScores.ToString() + " 点";
                        break;
                    case 3:
                        PlayerNames[3].text = OR_SaveSystem.Instance.SaveData.RK_Stage4_PlayerNames;
                        Stage_MaxScores[3].text = OR_SaveSystem.Instance.SaveData.Stage4_MaxScores.ToString() + " 点";
                        break;
                    case 4:
                        PlayerNames[4].text = OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames;
                        Stage_MaxScores[4].text = OR_SaveSystem.Instance.SaveData.Stage5_MaxScores.ToString() + " 点";
                        break;
                    case 5:
                        PlayerNames[5].text = OR_SaveSystem.Instance.SaveData.RK_Stage5_PlayerNames;
                        Stage_MaxScores[5].text = OR_SaveSystem.Instance.SaveData.Stage5_MaxScores.ToString() + " 点";
                        break;
                }
            }
        }
    }
}
