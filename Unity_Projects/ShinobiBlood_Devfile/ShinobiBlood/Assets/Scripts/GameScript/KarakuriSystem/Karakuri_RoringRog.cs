using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
   public class Karakuri_RoringRog : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        private void Start()
        {
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        }

        private void onCollisionStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && !_PlayerStatus.isHit)
            {
                _PlayerStatus.isHit = true;
                _PlayerStatus.KarakuriGetDamage = 10.0f;    
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "DestroyArea")
            {
                Destroy(this.gameObject);
            }
        }
    }
}

