using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBlock : MonoBehaviour
{
    [SerializeField] GameObject block;
    MG_HealthSystem _mghealthsystem;
    // Start is called before the first frame update
    void Start()
    {
        _mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
        block.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(!block.active && other.gameObject.tag == "Player" && Input.GetKeyDown("e"))
        {
            _mghealthsystem.TokenDamage(5.0f);
            //_mghealthsystem = GameObject.Find("Player").GetComponent<MG_HealthSystem>();
            block.SetActive(true);
        }
    }
}
