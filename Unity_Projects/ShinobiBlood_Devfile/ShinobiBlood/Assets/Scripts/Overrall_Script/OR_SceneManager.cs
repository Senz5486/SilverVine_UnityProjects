using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OR_SceneManager : MonoBehaviour
{
    //MusicCountroller
    MusicController _MusicController;
    //ASync
    private AsyncOperation async;           //AsyncOperation

    //String
    public string SceneName;      //読み込むシーン名

    //Loading Random1 の時のTips
    [SerializeField] private string RandomTips1 = "ステージによって、減る体力量は違う！難しいステージに行けば行くほど、減る体力が増え難易度が上昇するぞ・・・！";

    //Loading Random2 の時のTips
    [SerializeField] private string RandomTips2 = "実は、開発当時はキャラクター案が3つあった！今後増えるかもしれない・・・？";

    //Loading Random3 の時のTips
    [SerializeField] private string RandomTips3 = "ゲームのメインキャラクターについて　　　　　　　　　　忍者の家系に産まれた黒魔術師というのが主人公の設定だ！"; 

    //Int
    private int LoadingRandom;

    //bool
    private bool isLoading;

    //GameObject
    [SerializeField] private GameObject LoadingUI;  //ローディングUI

    //Image
    [SerializeField] private Image LoadingBar;      //NowLoadingのプログレスバーの指定

    //Text
    [SerializeField] private Text ProgressText;     //プログレステキスト
    [SerializeField] private Text Tips;             //Tipsテキスト

    private void Awake()
    {
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        isLoading = false;
        LoadingRandom = Random.Range(1, 4); //ランダム整数 1 - 3
        switch (LoadingRandom)
        {
            case 1:
                Tips.text = RandomTips1;
                break;
            case 2:
                Tips.text = RandomTips2;
                break;
            case 3:
                Tips.text = RandomTips3;
                break;
        }
    }
    //次のシーンへ移動するシステム
    //次のシーンへ移動したいときは NextSceneLoad()関数をご使用ください。
    //↓ 使い方 ↓
    //1 -  そのシーンに空のゲームオブジェクトを配置し、このスクリプトを設定します。
    //2 -  SceneNameに読み込ませたいシーンの名前を入力します。
    //3 -  そのオブジェクトからこのスクリプトを読み込んで 任意のタイミングで NextSceneLoadを実行します
    public void NextSceneLoad()
    {
        if (!isLoading)
        {
            LoadingUI.SetActive(true);       
            StartCoroutine("LoadAsyncSceneSystem");
            isLoading = true;
        }
    }


    //ローディングシステム 
    IEnumerator LoadAsyncSceneSystem()
    {
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        //シーンが読み終わるまで待つ
        while (async.progress < 0.9f)
        {
            ProgressText.text = (async.progress * 100).ToString("0") + "%";
            LoadingBar.fillAmount = async.progress;
            yield return null;
        }
        ProgressText.text = "100%";
        LoadingBar.fillAmount = 1.0f;
        yield return new WaitForSeconds(1.25f); //待ち時間
        async.allowSceneActivation = true;
    }
    void stopMusic()
    {
    }
}
