using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    //Gameobjects
    private Rigidbody rb = null;
    public GroundCheck ground;
    public GroundCheck head;

    //float
    [SerializeField] private float Gravity;
    [SerializeField] private float Player_JumpSpeed;
    [SerializeField] private float Player_JumpPos;
    [SerializeField] private float Player_JumpLimitHeight;
    [SerializeField] private float JumpLimitTime;
    [SerializeField] private float JumpTime;
    public float Player_Speed;

    //bool
    [SerializeField] private bool isGround;
    [SerializeField] private bool isHead;
    [SerializeField] private bool isJump;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
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

        //キー入力
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //速度
        float X_Speed = 0.0f;
        float Y_Speed = -Gravity;

        if (isGround)
        {
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
            if(PushVecKey && Player_CanJump && Player_CanTime && !isHead)
            {
                Y_Speed = Player_JumpSpeed;
                JumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                JumpTime = 0.0f;
            }
        }

        if (Horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            X_Speed = Player_Speed;
        }
        else if (Horizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            X_Speed = -Player_Speed;
        }

        rb.velocity = new Vector3(X_Speed, Y_Speed, 0);
    }

}
