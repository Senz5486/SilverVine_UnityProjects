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
        PlayerCamera _PlayerCamera;
        Animator _Animator;
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
        private float Horizontal;
        private float Vertical;
        [SerializeField] private float FirstRotateY;
        //��]
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
            Horizontal = 0.0f;
            Vertical = 0.0f;
            Y_Rotate = FirstRotateY;
            _PlayerCamera = GameObject.Find("ScriptObject").GetComponent<PlayerCamera>();
            _Animator = this.GetComponent<Animator>();
            rb = this.GetComponent<Rigidbody>();
            Default_Player_Speed = Player_Speed;
        }

        private void Update()
        {
            //�L�[����
                Horizontal = Input.GetAxis("Horizontal");
                Vertical   = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Q)) //�J�������]
            {
                if (!_PlayerCamera.PlayerReverse)
                {
                    _PlayerCamera.PlayerReverse = true;
                    return;
                }
                if (_PlayerCamera.PlayerReverse)
                {
                    _PlayerCamera.PlayerReverse = false;
                    return;
                }
            }
        }

        void FixedUpdate()
        {
            CharacterMovement();
        }

        void CharacterMovement()
        {
            //�ݒu����
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

            //���x
            float X_Speed = 0.0f;
            float Y_Speed = -Gravity * GravityFallTime;


                if (isGround)
                {
                    GravityFallTime = 0.0f;
                    if (Vertical > 0)
                    {
                        if (EnableCharaSystem)
                        {
                            Y_Speed = Player_JumpSpeed;
                            Player_JumpPos = transform.position.y;
                            isJump = true;
                            JumpTime = 0.0f;
                            _Animator.SetBool("IsJump", true);
                        }                
                    }
                    else
                    {
                        isJump = false;
                        _Animator.SetBool("IsJump", false);
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
                        _Animator.SetBool("IsJump", false);
                        isJump = false;
                        GravityFallTime = 0.0f;
                        JumpTime = 0.0f;
                    }
                }
                else if (isGround == false)
                {
                    GravityFallTime += Time.deltaTime * 1.2f;
                }
            if (EnableCharaSystem)
            {
                if (Horizontal > 0) //�E�ړ���
                {
                    Y_Rotate = 90;
                    X_Speed = Player_Speed * Horizontal;
                    _Animator.SetBool("IsRun", true);
                }
                else if (Horizontal < 0) //���ړ���
                {
                    Y_Rotate = -90;
                    X_Speed = Player_Speed * Horizontal;
                    _Animator.SetBool("IsRun", true);
                }
                else
                {
                    _Animator.SetBool("IsRun", false);
                }
            }
            else
            {
                _Animator.SetBool("IsRun", false);
            }
            transform.rotation = Quaternion.Euler(0, Y_Rotate, 0);
            rb.velocity = new Vector3(X_Speed, Y_Speed, 0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "MoveOBJ")//�������̂ɏ������
            {
                transform.SetParent(collision.transform);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "MoveOBJ")//�������̂ɏ������
            {
                transform.SetParent(null);
            }
        }
    }
}
