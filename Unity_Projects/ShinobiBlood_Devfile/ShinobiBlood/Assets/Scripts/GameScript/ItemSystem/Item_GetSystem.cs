using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Item_GetSystem : MonoBehaviour
{
    PlayerController _playerController;
    MG_HealthSystem _mghealthsystem;
    SoundController _SoundController;
    Tutorial_MainSystem _tutorial;
    string Item_Name;        //�A�C�e����
    public int Item_Type;           //�A�C�e���^�C�v (1: �񕜃A�C�e��/2:���x�㏸�A�C�e��)
    float Item_HealPower;           //�A�C�e��1�̃q�[���p���[
    float Item_SpeedPower;          //�A�C�e��2�̑��x�㏸��
    public float isSpeedTime;       //�A�C�e��2�̑��x�㏸����
    [SerializeField] private TextMesh Item_DisplayName = null;
    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
        {
            _tutorial = GameObject.Find("ScriptObject").GetComponent<Tutorial_MainSystem>();
        }
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
                Item_SpeedPower = 0.0f;
                isSpeedTime = 0.0f;
                break;
            case 2://���x�㏸�A�C�e���̏ꍇ
                Item_Name = "KSK-5";
                Item_DisplayName.text = Item_Name;
                Item_SpeedPower = 2.0f;
                isSpeedTime = 3.0f;
                Item_HealPower = 0.0f;
                break;
        }
    }
    private void OnTriggerEnter(Collider Player)
    {//�I�u�W�F�N�g��Player���ǂ�����1�x�̔��ʂōςނ悤�ɁA����Destroy�̏ꏊ���P������
        if(Player.gameObject.tag == "Player")//�v���C���[�ɐG�ꂽ�Ƃ�
        {
            switch (Item_Type)
            {
                case 1://�񕜃A�C�e���̏ꍇ
                    _mghealthsystem.TokenDamage(-Item_HealPower);
                    _SoundController.PlaySEAudio = 0;
                    if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
                    {
                        _tutorial.isGetHealItem = true;
                    }
                    if (_mghealthsystem.CurrentHealth >= _mghealthsystem.MaxHealth)//�̗͍ő�l�␳ 
                    {
                        _mghealthsystem.CurrentHealth = _mghealthsystem.MaxHealth;
                        _mghealthsystem.TokenDamage(-_mghealthsystem.MaxHealth);
                    }
                    break;
                case 2://�����A�C�e���̏ꍇ
                    _playerController.SpeedItemPower = 3;
                    _playerController.AccelerationSpeed = true;
                    _SoundController.PlaySEAudio = 0;
                    if (SceneManager.GetActiveScene().name == "Stage_Tutorial")
                    {
                        _tutorial.isGetSpeedItem = true;
                    }
                    break;
            }
            Destroy(this.gameObject);//�A�C�e������
        }


        //if (Player.gameObject.tag == "Player" && Item_Type == 1) //�񕜃A�C�e���ɐG�ꂽ��
        //{
        //    _mghealthsystem.CurrentHealth += Item_HealPower;
        //    if(_mghealthsystem.CurrentHealth >= _mghealthsystem.MaxHealth)
        //    {
        //        _mghealthsystem.CurrentHealth = _mghealthsystem.MaxHealth;
        //    }

        //    Destroy(this.gameObject);//�G�ꂽ���̂��̃I�u�W�F�N�g��j�󂷂� <--- �ŏI����
        //}

        //if (Player.gameObject.tag == "Player" && Item_Type == 2) //���x�㏸�A�C�e���ɐG�ꂽ��
        //{

        //    _playerController.SpeedItemPower = Item_SpeedPower;
        //    _playerController.SpeedItemTime += isSpeedTime;
        //    Destroy(this.gameObject);//�G�ꂽ���̂��̃I�u�W�F�N�g��j�󂷂� <--- �ŏI����
        //} 

    }
}
