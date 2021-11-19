using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program
{
    public class MG_GimikCast : MonoBehaviour
    {
        //GameObject
        [SerializeField] private GameObject CastUI;
        [SerializeField] private Image CastBar;
        //Getter / Setter
        private bool _startcast;
        public bool StartCast { set { _startcast = value; } }

        private bool IsCast;
        

        private float CastTime;
        private float MaxCastTime = 3.0f;

        private bool _finishcast;

        public bool FinishCast { get { return _finishcast; } set { _finishcast = value; } }

        void Start()
        {
            IsCast = false;
            CastUI.SetActive(false);
        }

        void FixedUpdate()
        {

            if (_startcast && !_finishcast)
            {
                CastTime = MaxCastTime;
                IsCast = true;
                _startcast = false;
            }

            if (IsCast)
            {
                CastUI.SetActive(true);
                CastTime -= Time.deltaTime;
                CastBar.fillAmount = MaxCastTime / CastTime;
                if (CastTime <= 0)
                {
                    CastTime = 0;
                    _finishcast = true;
                    IsCast = false;
                }
            }
            else
            {
                CastUI.SetActive(false);
            }

        }
    }
}
