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
        private float _NoHitTime;     //�������Ă��Ȃ����Ԃ�float
        private float _MaxNoHitTime;  //�ő�̓������Ă��Ȃ����Ԃ�float
        private float _KarakuriGetDamage;     //�󂯂��_���[�W
        public float KarakuriGetDamage { get { return _KarakuriGetDamage; } set { _KarakuriGetDamage = value; } }

        //bool
        private bool _isHit;          //�M�~�b�N�ɓ����������ǂ����̊m�F
        public bool isHit { get { return _isHit; } set { _isHit = value; } }


        private bool _isNoHit;        //nohit�����ǂ����̊m�F
        public bool isNoHit { get { return _isNoHit; } set { _isNoHit = value; } }


        private bool _isMiliHealth;   //�~���̗͂��ǂ����̊m�F
        public bool isMiliHealth { get { return _isMiliHealth; } set { _isMiliHealth = value; } }


        //int
        private int _RespawnCount;    //���X�|�[����
        public int RespawnCount { get { return _RespawnCount; } set { _RespawnCount = value; } }


        private int _Player_GetItems; //�v���C���[�̃A�C�e���l����
        public int Player_GetItems { get { return _Player_GetItems; } set { _Player_GetItems = value; } }

        //�{�[�i�XCheck�X�e�[�^�X
        private bool _Bonus_NoHit;
        private bool _Bonus_MiliHealth;
        private bool _Bonus_NoItem;
        private bool _Bonus_RespawnLv1;
        private bool _Bonus_RespawnLv2;

        public bool Bonus_NoHit { get { return _Bonus_NoHit; } set { _Bonus_NoHit = value; } }
        public bool Bonus_MiliHealth { get { return _Bonus_MiliHealth; } set { _Bonus_MiliHealth = value; } }
        public bool Bonus_NoItem { get { return _Bonus_NoItem; } set { _Bonus_NoItem = value; } }
        public bool Bonus_RespawnLv1 { get { return _Bonus_RespawnLv1; } set { _Bonus_RespawnLv1 = value; } }
        public bool Bonus_RespawnLv2 { get { return _Bonus_RespawnLv2; } set { _Bonus_RespawnLv2 = value; } }

        //���Z�`�F�b�N�X�e�[�^�X
        private int _Plus_HealthScore;
        private int _Plus_ItemScore;
        private int _Plus_ClearTimeScore;

        public int Plus_HealthScore { get { return _Plus_HealthScore; } set { _Plus_HealthScore = value; } }
        public int Plus_ItemScore { get { return _Plus_ItemScore; } set { _Plus_ItemScore = value; } }
        public int Plus_ClearTimeScore { get { return _Plus_ClearTimeScore; } set { _Plus_ClearTimeScore = value; } }

        private void Start()
        {
            _HealthSystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _Player_GetItems = 0;
            _NoHitTime = 0;
            _isNoHit = true;
            _isMiliHealth = false;
        }
        private void FixedUpdate()
        {
            MassStatus();
        }
        void MassStatus()
        {
            if (_HealthSystem.isStart) 
            {
                if (!_isHit)
                {
                    _NoHitTime += Time.deltaTime;
                    if (_NoHitTime >= _MaxNoHitTime)
                    {
                        _MaxNoHitTime = _NoHitTime;
                    }
                }
                else if (_isHit || _KarakuriGetDamage >= 1)
                {
                    _HealthSystem.TokenDamage(_KarakuriGetDamage);
                    _NoHitTime = 0.0f;
                    _KarakuriGetDamage = 0.0f;
                    _isNoHit = false;
                    _isHit = false;
                }
            }
            if(_HealthSystem.CurrentHealth <= 10)
            {
                _isMiliHealth = true;
            }
            else
            {
                _isMiliHealth = false;
            }
        }
    }
}

