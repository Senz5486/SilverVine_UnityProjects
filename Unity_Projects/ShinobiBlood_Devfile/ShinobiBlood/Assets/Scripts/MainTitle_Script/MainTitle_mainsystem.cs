using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTitle_mainsystem : MonoBehaviour
{
    #region タイトル画面に必要な物
    //GameObjects
    [SerializeField] private Image GameLogo; // ゲームのロゴ
    [SerializeField] private Text SubTitle; //ゲームのロゴの下に入れる文字
    [SerializeField] private GameObject SceneManagerObject; //シーンマネージャーを設定してるオブジェクト参照
    OR_SceneManager _orSceneManager; //OR_SceneManager
    //Vector&RectTransform
    [SerializeField] private Vector2 LogoPos; //ロゴのポジション
    [SerializeField] private RectTransform RectTrans; //ロゴの場所
    //Float
    [SerializeField] private float BlinkSpeed;      //点滅速度
    [SerializeField] private float BlinkTimer;
    [SerializeField] private float LogoMoveHeight; //どこまで動くか
    [SerializeField] private float LogoMoveSpeed; //ロゴが動く速度
    //Bool
    [SerializeField] private bool isMoveLogo;
    [SerializeField] private bool isLogoMaxHeight;
    [SerializeField] private bool once;
    //SoundObject
    [SerializeField] private SoundController _SoundController;
    [SerializeField] private MusicController _MusicController;
    
    #endregion

    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        _orSceneManager = SceneManagerObject.GetComponent<OR_SceneManager>(); 
        RectTrans = GameLogo.GetComponent<RectTransform>(); 
        LogoPos = RectTrans.anchoredPosition;
        isLogoMaxHeight = false;
        isMoveLogo = true;
        SubTitle.text = "スペースキー を押してスタート"; //サブタイトルの表示文字を設定 (Def:Press Any Key) 
        Invoke("PlayMusic", 0.1f);
        
    }

    void Update()
    {
        MainTitleAnimationSystem();
        AnyKeyPush();
    }

    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = 4;
    }

    void AnyKeyPush()
    {
        if (once == false) {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _SoundController.PlaySEAudio = 6;
                _orSceneManager.NextSceneLoad();
                once = true;
            }
            else
            {
                _SoundController.PlaySEAudio = -3;
            }
        }
    }

    void MainTitleAnimationSystem() //タイトルのロゴやサブタイトルのアニメーションシステム
    {

        #region ロゴが上下に動くアニメーション 
        //ロゴ用 (バグ修正済み: 2021/09/26 0:54 - 渡邊 # 状態:完成 #)
        if (isMoveLogo == true)
        {
            if (isLogoMaxHeight == false)
            {
                LogoPos.y += LogoMoveSpeed;
                if (LogoPos.y >= LogoMoveHeight)
                {
                    isLogoMaxHeight = true;
                }
            }
            if (isLogoMaxHeight == true)
            {
                LogoPos.y -= LogoMoveSpeed;
                if (LogoPos.y <= -LogoMoveHeight)
                {
                    isLogoMaxHeight = false;
                }
            }
        }
        RectTrans.anchoredPosition = LogoPos;
        //ロゴ用
        #endregion

        #region サブタイトルが点滅するアニメーション
        //サブタイトル用 (バグ無し: 2021/09/26 1:03 - 渡邊 # 状態:完成 #)

        SubTitle.color = GetAlphaColor(SubTitle.color);

        Color GetAlphaColor(Color color)
        {
            BlinkTimer += Time.deltaTime * 5.0f * BlinkSpeed;
            color.a = Mathf.Sin(BlinkTimer) * 0.5f + 0.5f;

            return color;
        }
        //サブタイトル用
        #endregion
    }
}
