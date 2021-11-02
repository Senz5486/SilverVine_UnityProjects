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

        public bool PlayerReverse = false;

        private bool isCollisionCameraLeft = false;
        private bool isCollisionCameraRight = false;

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
            if (PlayerReverse)
            {
                if (!isCollisionCameraLeft ||
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
            }
            else if (!PlayerReverse)
            {
                if(!isCollisionCameraRight ||
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
            }          
        }

        private bool checkDistance(float check1 , float check2 , float distance)
        {
            return Mathf.Abs(Mathf.Abs(check1) - Mathf.Abs(check2)) <= distance;
        }

        private void OnCollisionEnter(Collision other)
        {
            Vector3 hitPos = new Vector3(0, 0, 0);
            foreach (ContactPoint point in other.contacts)
            {
                hitPos = point.point;
            }

            if(hitPos.x < Player_Camera.transform.position.x)
            {
                isCollisionCameraRight = true;
            }
            else
            {
                isCollisionCameraLeft = true;
            }

        }

        private void OnCollisionExit(Collision other)
        {
            Vector3 hitPos = new Vector3(0, 0, 0);
            foreach (ContactPoint point in other.contacts)
            {
                hitPos = point.point;
            }

            if (hitPos.x < Player_Camera.transform.position.x)
            {
                isCollisionCameraRight = false;
            }
            else
            {
                isCollisionCameraLeft = false;
            }
        }
    }
}
