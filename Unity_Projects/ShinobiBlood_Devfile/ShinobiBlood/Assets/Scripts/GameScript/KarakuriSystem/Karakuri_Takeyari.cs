using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class Karakuri_Takeyari : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        bool isStay_Karakuri;

        private void Start()
        {
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            if (isStay_Karakuri)
            {
                _PlayerStatus.KarakuriGetDamage = 5.0f;
            }
            else
            {

            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                _PlayerStatus.isHit = true;
                isStay_Karakuri = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {

                isStay_Karakuri = false;
            }
        }
    }
}
