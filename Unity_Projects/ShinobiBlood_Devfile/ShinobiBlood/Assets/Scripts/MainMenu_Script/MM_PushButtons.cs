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
        }

        public void PushGameStart()
        {

            if (!OR_SaveSystem.Instance.SaveData.FinishTutorial) //èââÒÉvÉåÉCÇæÇ¡ÇΩèÍçá
            {
                TutorialUI.SetActive(true);
                MainMenuUI.SetActive(false);
            }
            else if (OR_SaveSystem.Instance.SaveData.FinishTutorial) //ìÒâÒñ⁄à»ç~ÇÃèÍçá
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
            OR_SaveSystem.Instance.SaveData.FinishTutorial = true;
            OR_SaveSystem.Instance.Save();
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
    }
}
