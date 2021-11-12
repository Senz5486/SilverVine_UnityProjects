using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    MG_HealthSystem _mghealthsystem;
    [SerializeField] float Damage;

    // Start is called before the first frame update
    void Start()
    {
        _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)//�G�ꂽ��
    {
        if(collision.gameObject.tag == "Player")
        {
            _mghealthsystem.TokenDamage(Damage,false);
            //�m�b�N�o�b�N�����݂���Ȃ�΂����ɒǋL
        }
    }
}
