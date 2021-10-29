using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_BacktoRespawn : MonoBehaviour
{
    private Transform PlayerObject;
    private Vector3 FirstSpawnPosition;

    void Start()
    {
        PlayerObject = GameObject.Find("Player").GetComponent<Transform>();
        FirstSpawnPosition = PlayerObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerObject.transform.position = FirstSpawnPosition;
        }
    }
}
