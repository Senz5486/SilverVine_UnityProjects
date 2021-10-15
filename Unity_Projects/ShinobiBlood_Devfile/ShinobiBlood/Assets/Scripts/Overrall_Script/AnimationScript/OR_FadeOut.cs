using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OR_FadeOut : MonoBehaviour
{
    [SerializeField] private float FadeSpeed;
    float Red, Green, Blue, Alpha;

    public bool isFadeOut; //このフラグが有効になった時にフェードアウトを実行する

    Image FadeImage;
    private void Awake()
    { 
        FadeImage = this.GetComponent<Image>();
    }
    void Start()
    {
        Alpha = 255.0f;
        FadeImage.enabled = true;
        Red = FadeImage.color.r;
        Green = FadeImage.color.g;
        Blue = FadeImage.color.b;
        Alpha = FadeImage.color.a;
        Alpha = 0.0f;
        isFadeOut = true;
    }

    void FixedUpdate()
    {
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        FadeImage.enabled = true;
        Alpha += FadeSpeed;
        SetAlpha();
        if(Alpha >= 1)
        {
            FadeImage.enabled = false;
            isFadeOut = false;
        }

    }

    void SetAlpha()
    {
        FadeImage.color = new Color(Red, Green, Blue, Alpha);
    }
}
