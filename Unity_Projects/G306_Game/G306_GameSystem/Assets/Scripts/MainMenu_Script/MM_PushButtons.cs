using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_PushButtons : MonoBehaviour
{
    //Class
    OR_SceneManager _SceneManager;
    //GameObjects
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject StageSelectUI;
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
        ConfirmExit.SetActive(false);
    }
    public void PushGameStart()
    {
        if (isFirstPlay == true) //‰‰ñƒvƒŒƒC‚¾‚Á‚½ê‡
        {
            _SceneManager.SceneName = "Stage_Tutorial";
            _SceneManager.NextSceneLoad();
            isFirstPlay = false;
        }
        else if (isFirstPlay == false) //“ñ‰ñ–ÚˆÈ~‚Ìê‡
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
}
