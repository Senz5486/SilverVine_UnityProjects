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

    //Int
    [SerializeField] private int LoadingRandom;

    //GameObject
    [SerializeField] private GameObject LoadingUI;  //ローディングUI
    [SerializeField] private GameObject LoadingBG1;
    [SerializeField] private GameObject LoadingBG2;
    [SerializeField] private GameObject LoadingBG3;

    //Image
    [SerializeField] private Image LoadingBar;      //NowLoadingのプログレスバーの指定

    //Text
    [SerializeField] private Text ProgressText;     //プログレステキスト
    [SerializeField] private Text Tips;


    private void Awake()
    {
        LoadingRandom = Random.Range(1, 4);
        if(LoadingRandom == 1)
        {
            LoadingBG1.SetActive(true);
            LoadingBG2.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = "下記のキャラクターは現在作成中のラフ画です 作成者:横瀬";
        }
        if(LoadingRandom == 2)
        {
            LoadingBG2.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = "下記のキャラクターは現在作成中のラフ画です 作成者:齋藤";
        }
        if(LoadingRandom == 3)
        {
            LoadingBG3.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG2.SetActive(false);
            Tips.text = "下記のキャラクターは現在作成中のラフ画です 作成者:松田";
        }
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
        //シーンが読み終わるまで待つ
        while (!async.isDone)
        {
            ProgressText.text = (async.progress * 100) + "%";
            LoadingBar.fillAmount = async.progress;
            yield return null;
        }
    }
}
