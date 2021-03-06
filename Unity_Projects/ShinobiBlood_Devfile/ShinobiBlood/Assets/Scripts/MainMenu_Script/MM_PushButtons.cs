using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class MM_PushButtons : MonoBehaviour
    {
        //Class
        OR_SceneManager _SceneManager;

        //GameObjects
        [SerializeField] private GameObject MainMenuUI;
        [SerializeField] private GameObject TutorialUI;
        [SerializeField] private GameObject StageSelectUI;
        [SerializeField] private GameObject CreditUI;
        [SerializeField] private GameObject OptionUI;
        [SerializeField] private GameObject ConfirmExit;
        [SerializeField] private GameObject RankingUI;

        void Start()
        {
            OR_SaveSystem.Instance.Load();
            _SceneManager = this.GetComponent<OR_SceneManager>();
        }

        public void BacktoMainMenu()
        {
            MainMenuUI.SetActive(true);
            StageSelectUI.SetActive(false);
            OptionUI.SetActive(false);
            CreditUI.SetActive(false);
            ConfirmExit.SetActive(false);
            TutorialUI.SetActive(false);
            RankingUI.SetActive(false);
            OR_SaveSystem.Instance.Save();
        }

        public void PushGameStart()
        {

            if (!OR_SaveSystem.Instance.SaveData.FinishTutorial) //初回プレイだった場合
            {
                TutorialUI.SetActive(true);
                MainMenuUI.SetActive(false);
            }
            else if (OR_SaveSystem.Instance.SaveData.FinishTutorial) //二回目以降の場合
            {
                StageSelectUI.SetActive(true);
                MainMenuUI.SetActive(false);
            }

        }

        public void PushOption()
        {
            OptionUI.SetActive(true);
            MainMenuUI.SetActive(false);
        }

        public void PushExit()
        {
            MainMenuUI.SetActive(false);
            ConfirmExit.SetActive(true);
        }
        public void PushTutorialPlay()
        {
            _SceneManager.SceneName = "Stage_Tutorial";
            _SceneManager.NextSceneLoad();
        }
        public void PushConfirmExit()
        {
            Application.Quit();
        }
        public void PushCredit()
        {
            CreditUI.SetActive(true);
            MainMenuUI.SetActive(false);
        }
        public void PushRanking()
        {
            RankingUI.SetActive(true);
            MainMenuUI.SetActive(false);
        }
    }
}
