using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Senz_Program
{
    public class Item_GetSystem : MonoBehaviour
    {
        Player_ParticleSystem _particle;
        PlayerController _playerController;
        MG_HealthSystem _mghealthsystem;
        SoundController _SoundController;
        Tutorial_MainSystem _tutorial;
        string Item_Name;        //�A�C�e����
        public int Item_Type;           //�A�C�e���^�C�v (1: �񕜃A�C�e��/2:���x�㏸�A�C�e��)
        float Item_HealPower;           //�A�C�e��1�̃q�[���p���[
        public float isSpeedTime;       //�A�C�e��2�̑��x�㏸����
        [SerializeField] private TextMesh Item_DisplayName = null;
        private void Awake()
        {
            _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
            if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
            {
                _tutorial = GameObject.Find("ScriptObject").GetComponent<Tutorial_MainSystem>();
            }
            _particle = GameObject.Find("Player").GetComponent<Player_ParticleSystem>();
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        }
        void Update()
        {
            switch (Item_Type)
            {
                case 1://�񕜃A�C�e���̏ꍇ
                    Item_Name = "ZOK-2";
                    Item_DisplayName.text = Item_Name;
                    Item_HealPower = 10.0f;
                    isSpeedTime = 0.0f;
                    break;
                case 2://���x�㏸�A�C�e���̏ꍇ
                    Item_Name = "KSK-5";
                    Item_DisplayName.text = Item_Name;
                    isSpeedTime = 3.0f;
                    Item_HealPower = 0.0f;
                    break;
            }
        }
        private void OnTriggerEnter(Collider Player)
        {//�I�u�W�F�N�g��Player���ǂ�����1�x�̔��ʂōςނ悤�ɁA����Destroy�̏ꏊ���P������
            if (Player.gameObject.tag == "Player")//�v���C���[�ɐG�ꂽ�Ƃ�
            {
                switch (Item_Type)
                {
                    case 1://�񕜃A�C�e���̏ꍇ
                        _mghealthsystem.TokenDamage(-Item_HealPower);
                        _SoundController.PlaySEAudio = 0;
                        _particle.isGetHealItem = true;
                        if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
                        {
                            _tutorial.isGetHealItem = true;
                        }
                        if (_mghealthsystem.CurrentHealth >= _mghealthsystem.MaxHealth)//�̗͍ő�l�␳ 
                        {
                            _mghealthsystem.CurrentHealth = _mghealthsystem.MaxHealth;
                        }
                        break;
                    case 2://�����A�C�e���̏ꍇ
                        _playerController.SpeedItemPower = 3;
                        _playerController.AccelerationSpeed = true;
                        _particle.isGetSpeedItem = true;
                        _SoundController.PlaySEAudio = 0;
                        if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
                        {
                            _tutorial.isGetSpeedItem = true;
                        }
                        break;
                }
                Destroy(this.gameObject);//�A�C�e������
            }
        }
    }
}
