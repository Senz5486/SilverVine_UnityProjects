using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class inviFloor : MonoBehaviour
    {
        PlayerController pc;
        [SerializeField] Collider collider;
        // Start is called before the first frame update
        void Start()
        {
            pc = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            collider.enabled = (pc.isRope ? false : true);
        }
    }
}
