using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Player_ParticleSystem : MonoBehaviour
    {
        public bool isGetHealItem;
        public bool isGetSpeedItem;
        public bool isCastGimik;

        public ParticleSystem[] Particles;

        private void Update()
        {
            PlayParticle();
        }

        void PlayParticle()
        {
            if (isGetHealItem)
            {
                if (!Particles[0].isPlaying)
                {
                    Particles[0].Play();
                }
                isGetHealItem = false;
            }
            if (isGetSpeedItem)
            {
                if (!Particles[1].isPlaying)
                {
                    Particles[1].Play();
                }
                isGetSpeedItem = false;
            }

            if (isCastGimik)
            {
                if (!Particles[2].isPlaying)
                {
                    Particles[2].Play();
                }
                isCastGimik = false;
            }
        }
    }
}
