using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakuri_Switch : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rigidbody.isKinematic = false;
        }
    }
}
