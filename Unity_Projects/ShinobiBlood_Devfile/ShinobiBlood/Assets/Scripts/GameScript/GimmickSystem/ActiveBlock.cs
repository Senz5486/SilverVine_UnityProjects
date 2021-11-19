using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program {
    public class ActiveBlock : MonoBehaviour
    {
        [SerializeField] GameObject block;
        [SerializeField] float Damage;
        MG_HealthSystem _mghealthsystem;
        MG_GimikCast _mggimikcast;
        // Start is called before the first frame update
        void Start()
        {
            _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _mggimikcast = GameObject.Find("Player").GetComponent<MG_GimikCast>();

            block.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (_mggimikcast.FinishCast)
            {
                _mghealthsystem.TokenDamage(Damage, false);
                block.SetActive(true);
                _mggimikcast.FinishCast = false;
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (!block.activeSelf && other.gameObject.tag == "Player" && Input.GetKeyDown("e") && !_mggimikcast.StartCast)
            {
                _mggimikcast.StartCast = true;
            }
        }
    }
}
