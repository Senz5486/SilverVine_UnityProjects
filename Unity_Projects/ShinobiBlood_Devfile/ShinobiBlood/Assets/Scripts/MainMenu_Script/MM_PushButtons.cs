using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MM_PushButtons : MonoBehaviour
{
    //Class
    OR_SceneManager _SceneManager;
    OR_JsonSystem _JsonManager;
    Save_Data save = new Save_Data();

    //GameObjects
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject TutorialUI;
    [SerializeField] private GameObject StageSelectUI;
    [SerializeField] private GameObject CreditUI;
    [SerializeField] private GameObject OptionUI;
    [SerializeField] private GameObject ConfirmExit;

    //bool
    public bool LoadedNeedTutorial;
    void Start()
    {
        _SceneManager = this.GetComponent<OR_SceneManager>();
        _JsonManager = this.GetComponent<OR_JsonSystem>();
        _JsonManager.SaveSystem();
        _JsonManager.LoadSystem(_JsonManager.FilePath);
        LoadedNeedTutorial = save.FinishTutorial;
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

        if (!save.FinishTutorial) //èââÒÉvÉåÉCÇæÇ¡ÇΩèÍçá
        {
            TutorialUI.SetActive(true);
            MainMenuUI.SetActive(false);
        }
        else if(save.FinishTutorial) //ìÒâÒñ⁄à»ç~ÇÃèÍçá
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
        save.FinishTutorial = true;
        _JsonManager.SaveSystem();
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
