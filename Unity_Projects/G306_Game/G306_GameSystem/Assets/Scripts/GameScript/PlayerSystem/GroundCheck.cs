using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGround;
    [SerializeField] private bool isGroundEnter, isGroundStay, isGroundExit;

    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    private void OnTriggerEnter(Collider other) //���肪��������
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay(Collider other) //���肪���葱���Ă����
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit(Collider other) //���肪��������
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundExit = true;
        }
    }
}
