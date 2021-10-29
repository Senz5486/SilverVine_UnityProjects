using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Score_Mass : MonoBehaviour
    {
        MG_HealthSystem _HealthSystem;
        PlayerStatus _PlayerStatus;
        int MassScore;
        private void Awake()
        {
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        }
        public int Score()
        {

            MassScore = (int)_HealthSystem.CurrentHealth * 1500;
            MassScore += _PlayerStatus.Player_GetItems * 500;
            

            if (_PlayerStatus.isNoHit)
            {
                MassScore += 10000;
            }
            if (_PlayerStatus.isMiliHealth)
            {
                MassScore += 50000;
            }

            return MassScore;
        }
    }
}
