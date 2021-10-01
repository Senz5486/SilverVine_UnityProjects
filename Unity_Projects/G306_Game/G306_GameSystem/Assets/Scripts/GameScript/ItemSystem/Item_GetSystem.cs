using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_GetSystem : MonoBehaviour
{
    string Item_Name;        //アイテム名
    public int Item_Type;           //アイテムタイプ (1: 回復アイテム/2:速度上昇アイテム)
    float Item_HealPower;           //アイテム1のヒールパワー
    float Item_SpeedPower;          //アイテム2の速度上昇率

    private void Awake()
    {
        switch (Item_Type)
        {
            case 1://回復アイテムの場合
                Item_Name = "ZOK-2";
                Item_SpeedPower = 0.0f;
                break;
            case 2://速度上昇アイテムの場合
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

        if (Player.gameObject.tag == "Player" && Item_Type == 1) //回復アイテムに触れた時
        {
            Destroy(this.gameObject);//触れた時のこのオブジェクトを破壊する <--- 最終処理
        }

        if (Player.gameObject.tag == "Player" && Item_Type == 2) //速度上昇アイテムに触れた時
        {
            Destroy(this.gameObject);//触れた時のこのオブジェクトを破壊する <--- 最終処理
        } 

    }

    void Update()
    {
        
    }
}
