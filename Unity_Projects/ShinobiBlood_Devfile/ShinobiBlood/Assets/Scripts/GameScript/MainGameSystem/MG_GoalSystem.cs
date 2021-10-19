using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class MG_GoalSystem : MonoBehaviour
    {
        public bool isGoalFlag;
        private void Start()
        {
            isGoalFlag = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                isGoalFlag = true;
            }
        }
    }
}
