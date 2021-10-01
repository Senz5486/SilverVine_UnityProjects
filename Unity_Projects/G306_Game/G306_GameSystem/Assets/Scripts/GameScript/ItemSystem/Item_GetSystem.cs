using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GetSystem : MonoBehaviour
{
    string Item_Name;        //�A�C�e����
    public int Item_Type;           //�A�C�e���^�C�v (1: �񕜃A�C�e��/2:���x�㏸�A�C�e��)
    float Item_HealPower;           //�A�C�e��1�̃q�[���p���[
    float Item_SpeedPower;          //�A�C�e��2�̑��x�㏸��

    private void Awake()
    {
        switch (Item_Type)
        {
            case 1://�񕜃A�C�e���̏ꍇ
                Item_Name = "ZOK-2";
                Item_SpeedPower = 0.0f;
                break;
            case 2://���x�㏸�A�C�e���̏ꍇ
                Item_Name = "KSK-5";
                Item_HealPower = 0.0f;
                break;
        }
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider Player)
    {

        if (Player.gameObject.tag == "Player" && Item_Type == 1) //�񕜃A�C�e���ɐG�ꂽ��
        {
            Destroy(this.gameObject);//�G�ꂽ���̂��̃I�u�W�F�N�g��j�󂷂� <--- �ŏI����
        }

        if (Player.gameObject.tag == "Player" && Item_Type == 2) //���x�㏸�A�C�e���ɐG�ꂽ��
        {
            Destroy(this.gameObject);//�G�ꂽ���̂��̃I�u�W�F�N�g��j�󂷂� <--- �ŏI����
        } 

    }

    void Update()
    {
        
    }
}
