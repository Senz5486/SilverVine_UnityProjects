using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program
{
    public class MG_GimikCast : MonoBehaviour
    {
        //GameObject
        Player_ParticleSystem _Particle;
        [SerializeField] private GameObject CastUI;
        [SerializeField] private Image CastBar;
        //Getter / Setter
        private bool _startcast;
        public bool StartCast { get { return _startcast; } set { _startcast = value; } }

        private bool _iscast;
        public bool IsCast { get { return _iscast; }set { _iscast = value; } }
        private float CastTime;
        private float MaxCastTime = 1.75f;
        private bool _finishcast;

        public bool FinishCast { get { return _finishcast; } set { _finishcast = value; } }

        void Start()
        {
            _Particle = this.GetComponent<Player_ParticleSystem>();
            IsCast = false;
            CastUI.SetActive(false);
        }

        void Update()
        {

            if (_startcast && !_finishcast && !_iscast)
            {
                CastTime = 0;
                _iscast = true;
                _startcast = false;
            }

            if (_iscast)
            {
                CastUI.SetActive(true);
                _Particle.Particles[2].Play();
                CastTime += Time.deltaTime;
                CastBar.fillAmount = CastTime / MaxCastTime;
                if (CastTime >= MaxCastTime)
                {
                    CastTime = MaxCastTime;
                    _finishcast = true;
                    _iscast = false;
                }
            }
            else
            {
                CastUI.SetActive(false);
            }

        }
    }
}
