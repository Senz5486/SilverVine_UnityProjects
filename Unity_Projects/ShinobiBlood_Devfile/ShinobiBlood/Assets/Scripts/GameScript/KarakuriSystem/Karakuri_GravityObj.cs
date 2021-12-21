using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Karakuri_GravityObj : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        Collider collider;
        bool used;
        private void Start()
        {
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
            collider = this.gameObject.GetComponent<MeshCollider>();
            used = false;
        }

        private void onCollisionStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && !used)  
            {
                if(!_PlayerStatus.isHit)
                {
                    _PlayerStatus.isHit = true;
                    _PlayerStatus.KarakuriGetDamage = 10.0f;
                }
                used = true;
            }
            if(collider.enabled && used)
            {
                collider.enabled = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "invalidArea" && !used)
            {
                used = true;
            }
        }
    }
}
