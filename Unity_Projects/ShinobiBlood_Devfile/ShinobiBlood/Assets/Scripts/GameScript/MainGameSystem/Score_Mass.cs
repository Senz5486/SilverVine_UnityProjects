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
            int MassScore = 0; //�ŏI�X�R�A

            MassScore += (int)_HealthSystem.CurrentHealth * 1500;        //���݂̗̑͂Ń|�C���g�����Z
            MassScore += _PlayerStatus.Player_GetItems * 500;           //�A�C�e���̎擾���ŉ��Z? -->�ύX�\���L
            MassScore += 1000000 / (int)_MainSystem.Stage_ProgressTime; //�N���A�������قǉ��Z --> �̗͂Ƃ͈Ⴂ�񕜂Ȃǂ����Ă��X�R�A�͑����Ȃ����S�ȃ^�C����

            NormalScore = MassScore;

            // NoHit Bonus 50,000Points
            if (_PlayerStatus.isNoHit)                                  //�m�[�q�b�g�N���A�������ꍇ
            {
                MassScore += 50000;
                _PlayerStatus.Bonus_NoHit = true;
            }

            //MiliHealth Bonus 25,000Points
            if (_PlayerStatus.isMiliHealth)                             //�~���̗͂������ꍇ
            {
                MassScore += 25000;
                _PlayerStatus.Bonus_MiliHealth = true;
            }

            //NoItem Bonus 100,000Points
            if (_PlayerStatus.Player_GetItems == 0)                      //�A�C�e�������ŃN���A�����ꍇ
            {
                MassScore += 100000;
                _PlayerStatus.Bonus_NoItem = true;
            }

            //NoRespawn Bonus ( 0 RespawnBonus : 100,000Points : 5 > RespawnBonus 25,000Points)
            if(_PlayerStatus.RespawnCount == 0)                          //�������X�|�[��(�w�肳�ꂽ�ʒu�֖߂�)���Ȃ������ꍇ�̃{�[�i�X
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
