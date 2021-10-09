using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //bool
    public bool isFirstPlay;

    void Start()
    {
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
        if (isFirstPlay == true) //èââÒÉvÉåÉCÇæÇ¡ÇΩèÍçá
        {
            TutorialUI.SetActive(true);
            MainMenuUI.SetActive(false);
            
        }
        else if (isFirstPlay == false) //ìÒâÒñ⁄à»ç~ÇÃèÍçá
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
        isFirstPlay = false;
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
