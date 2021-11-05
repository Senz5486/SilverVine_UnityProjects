using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Karakuri_RotationSaw : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        Transform SawTrans;
        private float RotateX;
        [SerializeField] private float RotationSpeed;
        void Start()
        {
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
            SawTrans = this.GetComponent<Transform>();
        }


        void Update()
        {
            RotateX -= RotationSpeed;
            SawTrans.rotation = Quaternion.Euler(RotateX, 90, 90);
            if(RotateX <= -360)
            {
                RotateX = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                _PlayerStatus.isHit = true;
                _PlayerStatus.KarakuriGetDamage += 10.0f;
            }
        }
    }
}