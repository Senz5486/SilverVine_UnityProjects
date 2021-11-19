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
        [SerializeField] private float Speed;
        void Start()
        {
            FadeImage = this.GetComponent<Image>();
            Dissolve = this.GetComponent<UIDissolve>();
        }


        void Update()
        {
            if(Dissolve.location <= 0)
            {
                FadeImage.enabled = false;
            }
            else
            {
                Dissolve.location -= Speed;
            }
        }
    }
}
