using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private float BlinkSpeed;
    [SerializeField] private float BlinkTimer;
    [SerializeField] private float LogoMoveHeight; //どこまで動くか
    //Bool
    [SerializeField] private bool isMoveLogo;
    [SerializeField] private bool isLogoMaxHeight;
    private bool UpdateOnce;
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
        UpdateOnce = true;
        SubTitle.text = "キーを押してスタート"; //サブタイトルの表示文字を設定 (Def:Press Any Key) 
        Invoke("PlayMusic", 0.5f);
        
    }

    void Update()
    {
        MainTitleAnimationSystem();
        AnyKeyPush();
    }

    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = 0;
    }

    void AnyKeyPush()
    {
        if (Input.anyKey)
        {
            _orSceneManager.NextSceneLoad();
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
                LogoPos.y += 0.03f;
                if (LogoPos.y >= LogoMoveHeight)
                {
                    isLogoMaxHeight = true;
                }
            }
            if (isLogoMaxHeight == true)
            {
                LogoPos.y -= 0.03f;
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
