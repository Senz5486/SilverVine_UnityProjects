using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
   public class Karakuri_RoringRog : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        [SerializeField] float RoringSpeed;
        Transform RogTrans;
        private float RotateZ;
        

        private void Start()
        {
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
            RogTrans = this.GetComponent<Transform>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            RotateZ += RoringSpeed;
            RogTrans.transform.position -= new Vector3(0.02f, 0, 0);
            RogTrans.transform.rotation = Quaternion.Euler(0, 0, RotateZ);
            if(RotateZ >= 360) { RotateZ -= 360; }
        }

        private void OnTriggerStay(Collider other)

        {
            if (other.gameObject.tag == "Player" && !_PlayerStatus.isHit)
            {
                _PlayerStatus.isHit = true;
                _PlayerStatus.KarakuriGetDamage = 10.0f;    
            }
        }
    }
}

