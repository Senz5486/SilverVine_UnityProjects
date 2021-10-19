using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantanObject : MonoBehaviour
{
    private bool isFire;
    void Start()
    {
        isFire = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isFire && other.gameObject.tag == "player" && Input.GetKeyDown("e"))
        {
            isFire = true;
        }
    }

    public bool GetFire()
    {
        return isFire;
    }
}
