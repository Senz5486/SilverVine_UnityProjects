using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class PlayerStatus : MonoBehaviour
    {
        //�v���C���[�X�e�[�^�X
        MG_HealthSystem _HealthSystem;
        
        //float
        public float NoHitTime;     //�������Ă��Ȃ����Ԃ�float
        public float MaxNoHitTime;  //�ő�̓������Ă��Ȃ����Ԃ�float
        public float KarakuriGetDamage;     //�󂯂��_���[�W

        //bool
        public bool isHit;          //�M�~�b�N�ɓ����������ǂ����̊m�F
        public bool isNoHit;        //nohit�����ǂ����̊m�F
        public bool isMiliHealth;   //�~���̗͂��ǂ����̊m�F

        //int
        public int RespawnCount;    //���X�|�[����
        public int Player_GetItems; //�v���C���[�̃A�C�e���l����


        //�{�[�i�XCheck�X�e�[�^�X
        public bool Bonus_NoHit;
        public bool Bonus_MiliHealth;
        public bool Bonus_NoItem;
        public bool Bonus_RespawnLv1;
        public bool Bonus_RespawnLv2;

        //���Z�`�F�b�N�X�e�[�^�X
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

