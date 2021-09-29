using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OR_SceneManager : MonoBehaviour
{
    //ASync
    private AsyncOperation async;           //AsyncOperation

    //String
    [SerializeField] private string SceneName;      //読み込むシーン名
    [SerializeField] private string RandomTips1; //Loading Random1 の時のTips
    [SerializeField] private string RandomTips2; //Loading Random2 の時のTips
    [SerializeField] private string RandomTips3; //Loading Random3 の時のTips
    //Int
    private int LoadingRandom;

    //GameObject
    [SerializeField] private GameObject LoadingUI;  //ローディングUI
    [SerializeField] private GameObject LoadingBG1; //ローディング Random1 の時の背景
    [SerializeField] private GameObject LoadingBG2; //ローディング Random2 の時の背景
    [SerializeField] private GameObject LoadingBG3; //ローディング Random3 の時の背景

    //Image
    [SerializeField] private Image LoadingBar;      //NowLoadingのプログレスバーの指定

    //Text
    [SerializeField] private Text ProgressText;     //プログレステキスト
    [SerializeField] private Text Tips;             //Tipsテキスト

    //MusicObject
    [SerializeField] private MusicController _MusicController;
    private void Awake()
    {
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        LoadingRandom = Random.Range(1, 4); //ランダム整数 1 - 3
        if (LoadingRandom == 1)
        {
            LoadingBG1.SetActive(true);
            LoadingBG2.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = RandomTips1;
        }
        if (LoadingRandom == 2)
        {
            LoadingBG2.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = RandomTips2;
        }
        if (LoadingRandom == 3)
        {
            LoadingBG3.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG2.SetActive(false);
            Tips.text = RandomTips3;
        }
    }
    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = -1;
    }
    //次のシーンへ移動するシステム (バグ無し: 2021/09/26 1:26 - 渡邊 # 状態:完成 #)
    //次のシーンへ移動したいときは NextSceneLoad()関数をご使用ください。
    //↓ 使い方 ↓
    //1 -  そのシーンに空のゲームオブジェクトを配置し、このスクリプトを設定します。
    //2 -  SceneNameに読み込ませたいシーンの名前を入力します。
    //3 -  そのオブジェクトからこのスクリプトを読み込んで 任意のタイミングで NextSceneLoadを実行します
    public void NextSceneLoad()
    {
        LoadingUI.SetActive(true);
        StartCoroutine("LoadAsyncSceneSystem");
    }

    //ローディングシステム (バグ無し: 2021/09/26 1:30 - 渡邊 # 状態:完成 #)
    IEnumerator LoadAsyncSceneSystem() 
    {
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        //シーンが読み終わるまで待つ
        while (async.progress < 0.9f)
        {
            ProgressText.text = (async.progress * 100) + "%";
            LoadingBar.fillAmount = async.progress;
            yield return null;
        }
            ProgressText.text = "100%";
            LoadingBar.fillAmount = 1.0f;
            yield return new WaitForSeconds(1.5f); //待ち時間
            async.allowSceneActivation = true;
    }
}
