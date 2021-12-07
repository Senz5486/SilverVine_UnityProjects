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
    private void OnTriggerEnter(Collider other) //”»’è‚ª“ü‚Á‚½Žž
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundEnter = true;
        }
    }
    private void OnTriggerStay(Collider other) //”»’è‚ª“ü‚è‘±‚¯‚Ä‚¢‚éŠÔ
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundStay = true;
        }
    }
    private void OnTriggerExit(Collider other) //”»’è‚ª”²‚¯‚½Žž
    {
        if (other.gameObject.tag == "Stage_GroundOBJ")
        {
            isGroundExit = true;
        }
    }
}
