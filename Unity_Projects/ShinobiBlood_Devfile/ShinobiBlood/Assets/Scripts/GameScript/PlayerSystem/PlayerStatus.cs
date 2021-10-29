using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class PlayerStatus : MonoBehaviour
    {
        //プレイヤーステータス
        MG_HealthSystem _HealthSystem;
        
        //float
        public float NoHitTime;     //当たっていない時間のfloat
        public float MaxNoHitTime;  //最大の当たっていない時間のfloat
        public float KarakuriGetDamage;     //受けたダメージ

        //bool
        public bool isHit;          //ギミックに当たったかどうかの確認
        public bool isNoHit;        //nohit中かどうかの確認
        public bool isMiliHealth;   //ミリ体力がどうかの確認

        //int
        public int RespawnCount;    //リスポーン回数
        public int Player_GetItems; //プレイヤーのアイテム獲得回数


        //ボーナスCheckステータス
        public bool Bonus_NoHit;
        public bool Bonus_MiliHealth;
        public bool Bonus_NoItem;
        public bool Bonus_RespawnLv1;
        public bool Bonus_RespawnLv2;

        //加算チェックステータス
        public int Plus_HealthScore;
        public int Plus_ItemScore;
        public int Plus_ClearTimeScore;
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
            if (_HealthSystem.isStart) 
            {
                if (!isHit)
                {
                    NoHitTime += Time.deltaTime;
                    if (NoHitTime >= MaxNoHitTime)
                    {
                        MaxNoHitTime = NoHitTime;
                    }
                }
                else if (isHit || KarakuriGetDamage >= 1)
                {
                    _HealthSystem.TokenDamage(KarakuriGetDamage);
                    NoHitTime = 0.0f;
                    KarakuriGetDamage = 0.0f;
                    isNoHit = false;
                    isHit = false;
                }
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

