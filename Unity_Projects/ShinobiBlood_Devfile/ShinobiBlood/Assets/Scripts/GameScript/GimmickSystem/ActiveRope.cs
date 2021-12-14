using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program {
    public class ActiveRope : MonoBehaviour
    {
        [SerializeField] GameObject rope;
        [SerializeField] float Damage;
        MG_HealthSystem _mghealthsystem;
        MG_GimikCast _mggimikcast;
        bool isEnd;
        bool isCast;
        // Start is called before the first frame update
        void Start()
        {
            _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _mggimikcast = GameObject.Find("Player").GetComponent<MG_GimikCast>();

            rope.SetActive(false);
            isEnd = false;
            isCast = false;
        }

        private void FixedUpdate()
        {
            if (isEnd) return;
            if (!_mggimikcast.StartCast && !_mggimikcast.IsCast && !_mggimikcast.FinishCast)
            {
                isCast = false;
            }
            if (_mggimikcast.FinishCast && isCast)
            {
                _mghealthsystem.TokenDamage(Damage, false);
                rope.SetActive(true);
                _mggimikcast.FinishCast = false;
                isEnd = true;
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (!isEnd && other.gameObject.tag == "Player" && Input.GetKeyDown("e") && !_mggimikcast.StartCast)
            {
                _mggimikcast.StartCast = true;
                isCast = true;
            }
        }
    }
}
