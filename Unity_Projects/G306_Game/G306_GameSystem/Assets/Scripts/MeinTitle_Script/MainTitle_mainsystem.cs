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

    //Vector
    Vector3 LogoPos;
    //Float

    //Bool
    public bool isMoveLogo;
    bool isLogoMaxHeight;
    #endregion

    private void Awake()
    {
        isMoveLogo = true;
        SubTitle.text = "キーを押してスタート"; //サブタイトルの表示文字を設定 (Def:Press Any Key)
    }


    void Update()
    {

        MainTitleAnimationSystem();
    }

    void MainTitleAnimationSystem() //タイトルのロゴやサブタイトルのアニメーションシステム
    {
        LogoPos = GameLogo.transform.position;
        if (isMoveLogo == true) // バグ発生中- 修正中
        {
            if(isLogoMaxHeight == false)
            {
                LogoPos.y += 0.1f;
                if(LogoPos.y >= 15.0f)
                {
                    isLogoMaxHeight = true;
                }
            }else if(isLogoMaxHeight == true){
                LogoPos.y -= 0.1f;
                if(LogoPos.y <= -15.0f)
                {
                    isLogoMaxHeight = false;
                }
            }
        }
        GameLogo.transform.position = LogoPos;
    }
}
