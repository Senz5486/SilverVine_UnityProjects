using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OR_SceneManager : MonoBehaviour
{
    private AsyncOperation async;           //AsyncOperation
    [SerializeField] private string SceneName;      //読み込むシーン名
    [SerializeField] private GameObject LoadingUI;  //ローディングUI
    [SerializeField] private Image LoadingBar;      //NowLoadingのプログレスバーの指定

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
            var ProgressValue = Mathf.Clamp01(async.progress / 0.9f);
            LoadingBar.fillAmount = ProgressValue;
            yield return null;
        }
    }
}
