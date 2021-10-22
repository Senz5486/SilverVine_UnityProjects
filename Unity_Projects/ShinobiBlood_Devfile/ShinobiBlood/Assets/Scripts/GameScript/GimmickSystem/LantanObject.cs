using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantanObject : MonoBehaviour
{
    [SerializeField]private bool isFire;
    void Start()
    {
        isFire = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isFire && other.gameObject.tag == "Player" && Input.GetKeyDown("e"))
        {
            isFire = true;
        }
    }

    public bool GetFire()
    {
        return isFire;
    }
}
