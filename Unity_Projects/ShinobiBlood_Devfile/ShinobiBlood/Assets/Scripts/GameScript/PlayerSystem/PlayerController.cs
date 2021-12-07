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

        MG_GimikCast _GimikCast;
        PlayerCamera _PlayerCamera;
        Animator _Animator;

        Player_ParticleSystem _Particle;
        //float
        [SerializeField] private float Gravity;
        [SerializeField] private float GravityFallTime;
        [SerializeField] private float Player_JumpSpeed;
        [SerializeField] private float Player_JumpPos;
        [SerializeField] private float Player_JumpLimitHeight;
        [SerializeField] private float JumpLimitTime;
        [SerializeField] private float JumpTime;
        [SerializeField] private float slopeForceRayLength;

        private float _speeditempower;
        public float SpeedItemPower {get {return _speeditempower;}set{_speeditempower = value;}  }
        [SerializeField]private float Player_Speed;
        Vector3 moveDirection;


        private float Default_Player_Speed;
        private float Horizontal;
        private float Vertical;
        [SerializeField] private float FirstRotateY;
        //回転
        float Y_Rotate;

        //bool
        [SerializeField] private bool isGround;
        [SerializeField] private bool isHead;
        [SerializeField] private bool CanAction;
        [SerializeField] private bool isJump;
        [SerializeField] private bool _isRope;
        public bool isRope { get { return _isRope; } }


        private bool _enablecharasystem;
        public bool EnableCharaSystem{get{return _enablecharasystem;}set{_enablecharasystem = value;}}

        private bool _accelerationspeed;
        public bool AccelerationSpeed{get{return _accelerationspeed;}set{_accelerationspeed = value;}}


        private void Awake()
        {
            Horizontal = 0.0f;
            Vertical = 0.0f;
            Y_Rotate = FirstRotateY;
            _PlayerCamera = GameObject.Find("Player_Track_Camera").GetComponent<PlayerCamera>();
            _GimikCast = this.GetComponent<MG_GimikCast>();
            _Animator = this.GetComponent<Animator>();
            rb = this.GetComponent<Rigidbody>();
            _Particle = this.GetComponent<Player_ParticleSystem>();
            Default_Player_Speed = Player_Speed;
            
        }

        private void Update()
        {
            //キー入力
            if(_enablecharasystem)
            {
                Horizontal = Input.GetAxis("Horizontal");
                Vertical = Input.GetAxis("Vertical");
                if(Horizontal != 0)
                {
                    _isRope = false;
                }
            }
            else
            {
                Horizontal = 0;
                Vertical = 0;
            }
            moveDirection.x = Horizontal;
            if (Input.GetKeyDown(KeyCode.Q)) //カメラ反転 2021/11/02 最適化
            {
                _PlayerCamera.PlayerReverse = !_PlayerCamera.PlayerReverse;
            }
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, Vector3.down, 
                out raycastHit, slopeForceRayLength))
            {
                float dot = Vector3.Dot(moveDirection, raycastHit.normal);
                if (dot <= 0.71f && dot >= -0.71f)
                {
                    moveDirection = moveDirection - dot * raycastHit.normal;
                }
            }
        }

        void FixedUpdate()
        {
            if (_isRope)
            {
                UseRope();
                return;
            }
            CharacterMovement();
        }

        void CharacterMovement()
        {
            //設置判定
            isGround = ground.IsGround();
            isHead = head.IsGround();
            CanAction = action.ActionArea();

            if (_accelerationspeed)
            {
                Player_Speed = Default_Player_Speed + SpeedItemPower;
                if (!_Particle.Particles[1].isPlaying)
                {
                    _Particle.Particles[1].Play();
                }
            }
            else if (!_accelerationspeed)
            {
                Player_Speed = Default_Player_Speed;
                _Particle.Particles[1].Stop();
                _speeditempower = 0;
            }

            //速度
            float X_Speed = 0.0f;
            float Y_Speed = -Gravity * GravityFallTime;
            
                if (isGround)
                {
                    GravityFallTime = 0.0f;
                    if (Vertical > 0)
                    {
                        if (_GimikCast.IsCast)
                        {
                            _GimikCast.IsCast = false;
                        }
                        Y_Speed = Player_JumpSpeed;
                        Player_JumpPos = transform.position.y;
                        isJump = true;
                        JumpTime = 0.0f;
                        _Animator.SetBool("IsJump", true);
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
                    if (_GimikCast.IsCast)
                    {
                        _GimikCast.IsCast = false;
                    }
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
                    GravityFallTime += Time.deltaTime;
                }

            if (_enablecharasystem)
            {
                if (Horizontal > 0) //右移動中
                {
                    if (_GimikCast.IsCast)
                    {
                        _GimikCast.IsCast = false;
                    }
                    Y_Rotate = 90;
                    X_Speed = Player_Speed * Horizontal;
                    _Animator.SetBool("IsRun", true);
                }
                else if (Horizontal < 0) //左移動中
                {
                    if (_GimikCast.IsCast)
                    {
                        _GimikCast.IsCast = false;
                    }
                    Y_Rotate = -90;
                    X_Speed = Player_Speed * Horizontal;
                    _Animator.SetBool("IsRun", true);
                }
                else
                {
                    _Animator.SetBool("IsRun", false);
                }
                transform.rotation = Quaternion.Euler(0, Y_Rotate, 0);
                rb.velocity = new Vector3(0, Y_Speed, 0) + moveDirection * Player_Speed;
            }
            else
            {
                _Animator.SetBool("IsRun", false);
            }
        }

        void UseRope()
        {
            float Y_Speed = Vertical * Player_Speed;
            rb.velocity = new Vector3(0, Y_Speed, 0);
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

        //private bool onSlope()
        //{
        //    if (isJump) return false;

        //    RaycastHit hit;

        //    if(Physics.Raycast(transform.position , Vector3.down , out hit , slopeForceRayLength))
        //    {
        //        if(hit.normal != Vector3.up)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
