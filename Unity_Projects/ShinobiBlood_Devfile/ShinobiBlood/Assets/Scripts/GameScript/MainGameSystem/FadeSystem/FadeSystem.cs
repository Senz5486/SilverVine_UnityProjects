using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
    public class FadeSystem : MonoBehaviour
    {
        Image FadeImage;
        UIDissolve Dissolve;
        [SerializeField] private float Speed = 0.001f;
        [SerializeField] private float Buffer;
        [SerializeField] private bool FadeOut;
        [SerializeField] private bool FadeIn;
        void Start()
        {
            FadeImage = this.GetComponent<Image>();
            Dissolve = this.GetComponent<UIDissolve>();
            if (FadeOut)
            {
                Buffer = 0;
            }
            else if (FadeIn)
            {
                Buffer = 1;
            }
        }


        void FixedUpdate()
        {
            if (FadeOut)
            {
                if (Buffer < 1)
                {
                    Buffer += Speed;
                    if (Buffer >= 1)
                    {
                        Buffer = 1;
                    }
                    Dissolve.location = Buffer;
                }
                else if (Buffer >= 1)
                {
                    if (FadeImage.enabled == true)
                    {
                        FadeImage.enabled = false;
                    }
                }
            }
            else if (FadeIn)
            {
                if (Buffer > 0)
                {
                    Buffer -= Speed;
                    if (Buffer <= 0)
                    {
                        Buffer = 0;
                    }
                    Dissolve.location = Buffer;
                }
                else if (Buffer <= 0)
                {
                    if (FadeImage.enabled == true)
                    {
                        FadeImage.enabled = false;
                    }
                }
            }

            
        }
    }
}
