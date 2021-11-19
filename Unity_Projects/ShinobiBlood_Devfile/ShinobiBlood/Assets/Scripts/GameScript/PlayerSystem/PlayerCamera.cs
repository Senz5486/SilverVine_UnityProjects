using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class PlayerCamera : MonoBehaviour
    {
        public Transform TargetObject;        //追いかけるオブジェクト

        [SerializeField] private float CameraDistance   = 9.0f;   // プレイヤーとの距離
        [SerializeField] private float Height           = 1.85f;   //カメラの高さ
        [SerializeField] private float SmoothSpeed      = 7.0f;   //カメラの追い付く速度

        [SerializeField] private Camera Player_Camera;

        private bool _playerreverse = false;
        public bool PlayerReverse{get{return _playerreverse;}set{_playerreverse = value;}}

        [SerializeField] private bool isCollisionCameraRight = false;
        [SerializeField] private bool isCollisionCameraLeft = false;

        private void Awake()
        {
            var Position = TargetObject.position + new Vector3(0.0f, Height, -CameraDistance);
            Player_Camera = GameObject.Find("Player_Track_Camera").GetComponent<Camera>();
            Player_Camera.transform.position = Position;
        }
        void Update()
        {
            CameraPlayerSmoothTracker();
        }

        void CameraPlayerSmoothTracker()
        {
            if (_playerreverse)
            {
                if (!isCollisionCameraRight ||
                    !checkDistance(Player_Camera.transform.position.x,
                    TargetObject.position.x, 2.5f))
                {
                    if (TargetObject.gameObject.tag == "Player")
                    {
                        var Position = TargetObject.position + new Vector3(2.5f, Height, -CameraDistance);
                        Player_Camera.transform.position = Vector3.Lerp(Player_Camera.transform.position, Position, Time.deltaTime * SmoothSpeed);
                    }
                    else if (TargetObject.gameObject.tag == "Item")
                    {
                        var Position = TargetObject.position + new Vector3(0.0f, Height, -CameraDistance);
                        Player_Camera.transform.position = Vector3.Lerp(Player_Camera.transform.position, Position, Time.deltaTime * SmoothSpeed);
                    }
                }
                else
                {
                    var Position = Player_Camera.transform.position;
                    Position.y = TargetObject.position.y + Height;
                    Player_Camera.transform.position = Position;
                }
            }
            else if (!_playerreverse)
            {
                if(!isCollisionCameraLeft ||
                   !checkDistance(Player_Camera.transform.position.x,
                   TargetObject.position.x, 2.5f))
                {
                    if (TargetObject.gameObject.tag == "Player")
                    {
                        var Position = TargetObject.position + new Vector3(-2.5f, Height, -CameraDistance);
                        Player_Camera.transform.position = Vector3.Lerp(Player_Camera.transform.position, Position, Time.deltaTime * SmoothSpeed);
                    }
                    else if (TargetObject.gameObject.tag == "Item")
                    {
                        var Position = TargetObject.position + new Vector3(2.5f, Height, -CameraDistance);
                        Player_Camera.transform.position = Vector3.Lerp(Player_Camera.transform.position, Position, Time.deltaTime * SmoothSpeed);
                    }
                }
                else
                {
                    var Position = Player_Camera.transform.position;
                    Position.y = TargetObject.position.y + Height;
                    Player_Camera.transform.position = Position;
                }
            }          
        }

        private bool checkDistance(float check1 , float check2 , float distance)
        {
            return Mathf.Abs(Mathf.Abs(check1) - Mathf.Abs(check2)) <= distance;
        }

        private void OnCollisionEnter(Collision other)
        {
            Vector3 hitPos = other.gameObject.transform.position;

            if (hitPos.x < Player_Camera.transform.position.x)
            {
                isCollisionCameraLeft = true;
            }
            else
            {
                isCollisionCameraRight = true;
            }

        }

        private void OnCollisionExit(Collision other)
        {
            Vector3 hitPos = other.gameObject.transform.position;

            if (hitPos.x < Player_Camera.transform.position.x)
            {
                isCollisionCameraLeft = false;
            }
            else
            {
                isCollisionCameraRight = false;
            }
        }
    }
}
