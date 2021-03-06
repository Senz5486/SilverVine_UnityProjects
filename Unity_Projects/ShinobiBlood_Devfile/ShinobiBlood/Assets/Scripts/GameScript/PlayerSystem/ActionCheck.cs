using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCheck : MonoBehaviour
{
    bool CanAction;
    [SerializeField] private bool CanActionArea, CanActionStay, CanActionExit;
    public bool ActionArea()
    {
        if (CanActionArea || CanActionStay)
        {
            CanAction = true;
        }
        else if (CanActionExit)
        {
            CanAction = false;
        }

        CanActionArea = false;
        CanActionStay = false;
        CanActionExit = false;
        return CanAction;
    }
    private void OnTriggerEnter(Collider other) //判定が入った時
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionArea = true;
        }
    }
    private void OnTriggerStay(Collider other) //判定が入り続けている間
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionStay = true;
        }
    }
    private void OnTriggerExit(Collider other) //判定が抜けた時
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionExit = true;
        }
    }
}
