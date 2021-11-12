using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Score_Mass : MonoBehaviour
    {
        MG_HealthSystem _HealthSystem;
        MG_MainSystem _MainSystem;
        PlayerStatus _PlayerStatus;
        
        public int NormalScore;
        public int AddScore;

        private void Awake()
        {
            _MainSystem = GameObject.Find("ScriptObject").GetComponent<MG_MainSystem>();
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        }
        public int Score()
        {
            int MassScore = 0; //最終スコア

            MassScore += (int)_HealthSystem.CurrentHealth * 1500;        //現在の体力でポイントが加算
            MassScore += _PlayerStatus.Player_GetItems * 500;           //アイテムの取得数で加算? -->変更可能性有
            MassScore += 1000000 / (int)_MainSystem.Stage_ProgressTime; //クリアが早いほど加算 --> 体力とは違い回復などをしてもスコアは増えない完全なタイム制

            NormalScore = MassScore;

            // NoHit Bonus 50,000Points
            if (_PlayerStatus.isNoHit)                                  //ノーヒットクリアだった場合
            {
                MassScore += 50000;
                _PlayerStatus.Bonus_NoHit = true;
            }

            //MiliHealth Bonus 25,000Points
            if (_PlayerStatus.isMiliHealth)                             //ミリ体力だった場合
            {
                MassScore += 25000;
                _PlayerStatus.Bonus_MiliHealth = true;
            }

            //NoItem Bonus 100,000Points
            if (_PlayerStatus.Player_GetItems == 0)                      //アイテム無しでクリアした場合
            {
                MassScore += 100000;
                _PlayerStatus.Bonus_NoItem = true;
            }

            //NoRespawn Bonus ( 0 RespawnBonus : 100,000Points : 5 > RespawnBonus 25,000Points)
            if(_PlayerStatus.RespawnCount == 0)                          //一回もリスポーン(指定された位置へ戻る)がなかった場合のボーナス
            {
                MassScore += 100000;
                _PlayerStatus.Bonus_RespawnLv2 = true;
            }
            else if (5 > _PlayerStatus.RespawnCount)
            {
                MassScore += 25000;
                _PlayerStatus.Bonus_RespawnLv1 = true;
            }

            AddScore = MassScore - NormalScore;

            return MassScore;
        }
    }
}
