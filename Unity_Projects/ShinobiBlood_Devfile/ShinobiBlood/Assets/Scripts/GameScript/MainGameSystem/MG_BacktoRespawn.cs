using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class MG_BacktoRespawn : MonoBehaviour
    {
        PlayerStatus _PlayerStatus;
        PlayerController _playerController;
        private Transform PlayerObject;
        private Vector3 FirstSpawnPosition;

        void Start() { 
            _PlayerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            PlayerObject = GameObject.Find("Player").GetComponent<Transform>();
            FirstSpawnPosition = PlayerObject.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                _playerController.AccelerationSpeed = false;
                PlayerObject.transform.position = FirstSpawnPosition;
                _PlayerStatus.RespawnCount++;
            }
        }
    }
}
