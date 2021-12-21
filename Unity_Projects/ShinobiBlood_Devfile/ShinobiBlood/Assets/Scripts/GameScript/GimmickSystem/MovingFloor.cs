using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] float MoveRadius;
    [SerializeField] float PowerFilter;
    private Vector3 initPos;
    void Awake()
    {
        initPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time / PowerFilter) * MoveRadius + initPos.x, initPos.y, initPos.z);
    }
}
