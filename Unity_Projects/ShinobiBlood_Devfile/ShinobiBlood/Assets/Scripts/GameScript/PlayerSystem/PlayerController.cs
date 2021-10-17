using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Senz_Program
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        //Gameobjects
        private Rigidbody rb = null;
        public GroundCheck ground;
        public GroundCheck head;
        public ActionCheck action;

        //float
        [SerializeField] private float Gravity;
        [SerializeField] private float GravityFallTime;
        [SerializeField] private float Player_JumpSpeed;
        [SerializeField] private float Player_JumpPos;
        [SerializeField] private float Player_JumpLimitHeight;
        [SerializeField] private float JumpLimitTime;
        [SerializeField] private float JumpTime;
        public float SpeedItemPower;
        public float Player_Speed;
        private float Default_Player_Speed;
        //回転
        float Y_Rotate;

        //bool
        [SerializeField] private bool isGround;
        [SerializeField] private bool isHead;
        [SerializeField] private bool CanAction;
        [SerializeField] private bool isJump;
        public bool EnableCharaSystem;
        public bool AccelerationSpeed;
        private void Awake()
        {
            rb = this.GetComponent<Rigidbody>();
            Y_Rotate = 90.0f;
            Default_Player_Speed = Player_Speed;
        }

        void FixedUpdate()
        {
            CharacterMovement();
        }

        void CharacterMovement()
        {
            //設置判定
            isGround = ground.IsGround();
            isHead = head.IsGround();
            CanAction = action.ActionArea();

            if (AccelerationSpeed)
            {
                Player_Speed = Default_Player_Speed + SpeedItemPower;
            }
            else if (!AccelerationSpeed)
            {
                Player_Speed = Default_Player_Speed;
                SpeedItemPower = 0;
            }


            //キー入力
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            //速度
            float X_Speed = 0.0f;
            float Y_Speed = -Gravity * GravityFallTime;


            if (EnableCharaSystem)
            {
                if (isGround)
                {
                    GravityFallTime = 0.0f;
                    if (Vertical > 0)
                    {
                        Y_Speed = Player_JumpSpeed;
                        Player_JumpPos = transform.position.y;
                        isJump = true;
                        JumpTime = 0.0f;
                    }
                    else
                    {
                        isJump = false;
                    }
                }
                else if (isJump)
                {
                    bool PushVecKey = Vertical > 0;
                    bool Player_CanJump = Player_JumpPos + Player_JumpLimitHeight > transform.position.y;
                    bool Player_CanTime = JumpLimitTime > JumpTime;
                    if (PushVecKey && Player_CanJump && Player_CanTime && !isHead)
                    {
                        Y_Speed = Player_JumpSpeed;
                        JumpTime += Time.deltaTime;
                    }
                    else
                    {
                        isJump = false;
                        GravityFallTime = 0.0f;
                        JumpTime = 0.0f;
                    }
                }
                else if (isGround == false)
                {
                    GravityFallTime += Time.deltaTime;
                }

                if (Horizontal > 0) //右移動中
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    Y_Rotate = 90;
                    X_Speed = Player_Speed * Horizontal;
                }
                else if (Horizontal < 0) //左移動中
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    Y_Rotate = -90;
                    X_Speed = Player_Speed * Horizontal;
                }
                else
                {
                    //transform.localScale = new Vector3(1, 1, 1);
                    //X_Speed = 0.0f;
                }
                transform.rotation = Quaternion.Euler(0, Y_Rotate, 0);
                rb.velocity = new Vector3(X_Speed, Y_Speed, 0);
            }
            else
            {
                Horizontal = 0;
                Vertical = 0;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "MoveOBJ")//動くものに乗った時
            {
                transform.SetParent(collision.transform);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "MoveOBJ")//動くものに乗った時
            {
                transform.SetParent(null);
            }
        }
    }
}
