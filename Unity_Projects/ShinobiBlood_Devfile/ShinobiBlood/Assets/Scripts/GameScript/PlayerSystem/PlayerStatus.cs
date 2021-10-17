using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class PlayerStatus : MonoBehaviour
    {
        MG_HealthSystem _HealthSystem;
        public int Player_GetItems;
        public float NoHitTime;
        public bool isNoHit;
        public bool isMiliHealth;
        private void Start()
        {
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            Player_GetItems = 0;
            NoHitTime = 0;
            isNoHit = true;
            isMiliHealth = false;
        }
        private void FixedUpdate()
        {
            MassStatus();
        }
        void MassStatus()
        {
            if (isNoHit)
            {
                NoHitTime += Time.deltaTime;
            }

            if(_HealthSystem.CurrentHealth <= 10)
            {
                isMiliHealth = true;
            }
            else
            {
                isMiliHealth = false;
            }
        }
    }
}

