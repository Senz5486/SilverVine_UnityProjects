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
    private void OnTriggerEnter(Collider other) //”»’è‚ª“ü‚Á‚½Žž
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionArea = true;
        }
    }
    private void OnTriggerStay(Collider other) //”»’è‚ª“ü‚è‘±‚¯‚Ä‚¢‚éŠÔ
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionStay = true;
        }
    }
    private void OnTriggerExit(Collider other) //”»’è‚ª”²‚¯‚½Žž
    {
        if (other.gameObject.tag == "Karakuri")
        {
            CanActionExit = true;
        }
    }
}
