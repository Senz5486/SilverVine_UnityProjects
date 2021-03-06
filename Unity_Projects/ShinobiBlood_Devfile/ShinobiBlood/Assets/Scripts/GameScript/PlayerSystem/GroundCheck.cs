using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGround;
    [SerializeField] private bool isGroundEnter, isGroundStay, isGroundExit;

    public bool IsGround()
    {
        if (isGroundExit)
        {
            isGround = false;
        }
        else if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    private void OnTriggerEnter(Collider other) //判定が入った時
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay(Collider other) //判定が入り続けている間
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit(Collider other) //判定が抜けた時
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundExit = true;
        }
    }
}
