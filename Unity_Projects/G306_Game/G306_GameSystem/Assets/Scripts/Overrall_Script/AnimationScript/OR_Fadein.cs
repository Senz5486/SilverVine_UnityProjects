using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OR_Fadein : MonoBehaviour
{
    [SerializeField] private float FadeSpeed;
    float Red, Green, Blue, Alpha;

    public bool isFadeIn; //このフラグが有効になった時にフェードアウトを実行する

    Image FadeImage;

    private void Awake()
    {
        Alpha = 255.0f;
    }
    void Start()
    {
        FadeImage = this.GetComponent<Image>();
        Red = FadeImage.color.r;
        Green = FadeImage.color.g;
        Blue = FadeImage.color.b;
        Alpha = FadeImage.color.a;
        isFadeIn = true;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }
    }

    void StartFadeIn()
    {
        FadeImage.enabled = true;
        Alpha -= FadeSpeed;
        SetAlpha();
        if (Alpha <= 0)
        {
            isFadeIn = false;
        }

    }

    void SetAlpha()
    {
        FadeImage.color = new Color(Red, Green, Blue, Alpha);
    }
}
