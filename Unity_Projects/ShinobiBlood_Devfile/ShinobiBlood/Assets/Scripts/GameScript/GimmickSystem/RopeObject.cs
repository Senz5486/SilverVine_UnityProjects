using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class RopeObject : MonoBehaviour
    {
        PlayerController pc;
        Transform pcPos;

        [SerializeField] Transform RopePosition;

        bool isStay;
        bool isStartAction;

        float startPos;

        float movePower;
        float time;
    
        // Start is called before the first frame update
        void Awake()
        {
            pc = GameObject.Find("Player").GetComponent<PlayerController>();
            isStay = false;
            isStartAction = false;
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
            if(isStay && !pc.isRope && Input.GetKeyUp("e"))
            {
                pc.RopeAction(RopePosition.position.x);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                isStay = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isStay = false;
            }
        }
    }
}

