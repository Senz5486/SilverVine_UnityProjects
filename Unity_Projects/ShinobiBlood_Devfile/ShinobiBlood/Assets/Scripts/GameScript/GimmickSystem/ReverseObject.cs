using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class ReverseObject : MonoBehaviour
    {
        [SerializeField] GameObject revarseArea;
        [SerializeField] float Damage;
        MG_HealthSystem _mghealthsystem;

        // Start is called before the first frame update
        void Start()
        {
            _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && Input.GetKeyDown("e"))
            {
                _mghealthsystem.TokenDamage(Damage, false);
                revarseArea.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
        }
    }
}