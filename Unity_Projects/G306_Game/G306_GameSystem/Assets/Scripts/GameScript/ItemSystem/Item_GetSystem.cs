using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item_GetSystem : MonoBehaviour
{
    PlayerController _playerController;
    MG_HealthSystem _mghealthsystem;
    string Item_Name;        //�A�C�e����
    public int Item_Type;           //�A�C�e���^�C�v (1: �񕜃A�C�e��/2:���x�㏸�A�C�e��)
    float Item_HealPower;           //�A�C�e��1�̃q�[���p���[
    float Item_SpeedPower;          //�A�C�e��2�̑��x�㏸��
    public float isSpeedTime;       //�A�C�e��2�̑��x�㏸����
    TextMesh Item_DisplayName = null;
    private void Awake()
    {
       Item_DisplayName = GameObject.Find("ItemText").GetComponent<TextMesh>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
    }
    private void FixedUpdate()
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
                    _mghealthsystem.CurrentHealth += Item_HealPower;
                    if (_mghealthsystem.CurrentHealth >= _mghealthsystem.MaxHealth)//�̗͍ő�l�␳ 
                    {
                        _mghealthsystem.CurrentHealth = _mghealthsystem.MaxHealth;
                    }
                    break;
                case 2://�����A�C�e���̏ꍇ
                    _playerController.SpeedItemPower = Item_SpeedPower;
                    _playerController.SpeedItemTime += isSpeedTime;
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

    void Update()
    {
        
    }
}
