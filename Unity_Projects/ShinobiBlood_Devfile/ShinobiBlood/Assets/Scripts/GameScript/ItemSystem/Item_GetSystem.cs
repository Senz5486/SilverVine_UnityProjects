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
        string Item_Name;        //アイテム名
        public int Item_Type;           //アイテムタイプ (1: 回復アイテム/2:速度上昇アイテム)
        float Item_HealPower;           //アイテム1のヒールパワー
        public float isSpeedTime;       //アイテム2の速度上昇時間
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
                case 1://回復アイテムの場合
                    Item_Name = "ZOK-2";
                    Item_DisplayName.text = Item_Name;
                    Item_HealPower = 10.0f;
                    isSpeedTime = 0.0f;
                    break;
                case 2://速度上昇アイテムの場合
                    Item_Name = "KSK-5";
                    Item_DisplayName.text = Item_Name;
                    isSpeedTime = 3.0f;
                    Item_HealPower = 0.0f;
                    break;
            }
        }
        private void OnTriggerEnter(Collider Player)
        {//オブジェクトがPlayerかどうかを1度の判別で済むように、かつDestroyの場所も１か所に
            if (Player.gameObject.tag == "Player")//プレイヤーに触れたとき
            {
                switch (Item_Type)
                {
                    case 1://回復アイテムの場合
                        _mghealthsystem.TokenDamage(-Item_HealPower);
                        _SoundController.PlaySEAudio = 0;
                        _particle.isGetHealItem = true;
                        if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
                        {
                            _tutorial.isGetHealItem = true;
                        }
                        if (_mghealthsystem.CurrentHealth >= _mghealthsystem.MaxHealth)//体力最大値補正 
                        {
                            _mghealthsystem.CurrentHealth = _mghealthsystem.MaxHealth;
                        }
                        break;
                    case 2://加速アイテムの場合
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
                Destroy(this.gameObject);//アイテム消去
            }
        }
    }
}
