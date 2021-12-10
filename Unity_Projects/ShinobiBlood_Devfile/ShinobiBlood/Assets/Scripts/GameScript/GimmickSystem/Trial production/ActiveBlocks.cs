using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class ActiveBlocks : MonoBehaviour
    {
        [SerializeField] private new BoxCollider collider;
        [SerializeField] float Damage;
        [SerializeField] private new MeshRenderer renderer;
        [SerializeField] private ParticleSystem OnFire;
        MG_HealthSystem _mghealthsystem;
        MG_GimikCast _mggimikcast;
        bool isEnd;

        private void Start()
        {
            _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            _mggimikcast = GameObject.Find("Player").GetComponent<MG_GimikCast>();
            collider.enabled = false;
            renderer.material.color = new Color32(0, 0, 0, 50);
            isEnd = false;
        }

        private void FixedUpdate()
        {
            if (_mggimikcast.FinishCast)
            {
                _mghealthsystem.TokenDamage(Damage, false);
                renderer.material.color = new Color32(0, 0, 0, 255);
                _mggimikcast.FinishCast = false;
                isEnd = true;
                collider.enabled = true;
                if (!OnFire.isPlaying) 
                {
                    OnFire.Play();
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!isEnd && other.gameObject.tag == "Player" && Input.GetKeyDown("e") && !_mggimikcast.StartCast)
            {
                _mggimikcast.StartCast = true;
            }
        }
    }
}
