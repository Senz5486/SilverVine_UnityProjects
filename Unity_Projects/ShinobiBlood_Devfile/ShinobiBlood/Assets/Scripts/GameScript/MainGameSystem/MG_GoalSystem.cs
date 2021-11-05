using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class MG_GoalSystem : MonoBehaviour
    {
        private bool _isgoalflag;

        public bool IsGoalFlag
        {
            get
            {
                return _isgoalflag;
            }
            set
            {
                _isgoalflag = value;
            }
        }
        private void Start()
        {
            _isgoalflag = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                _isgoalflag = true;
            }
        }
    }
}
