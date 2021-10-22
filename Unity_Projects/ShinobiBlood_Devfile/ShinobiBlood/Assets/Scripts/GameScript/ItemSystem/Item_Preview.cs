using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Preview : MonoBehaviour
{
    [SerializeField] private float HeightSpeed;
    [SerializeField] private float DefaultY;
    [SerializeField] private float HeightValue;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float RotateValue;
    [SerializeField] private GameObject PreviewItem;
    private Transform PreviewItemTrans;
    [SerializeField] private Vector3 ItemTransform;
    private Quaternion ItemRotate;
    [SerializeField] private float MaxHeight;
    [SerializeField] private bool isMaxHeight;
    private void Awake()
    {

        PreviewItemTrans = this.GetComponent<Transform>();
        ItemTransform = PreviewItemTrans.position;
        ItemRotate = PreviewItem.transform.rotation;
        DefaultY = ItemTransform.y;
        HeightValue = ItemTransform.y;
        MaxHeight = DefaultY + 0.5f;
    }

    void Update()
    {
        PreviewRotateItem();
        PreviewItemHeight();
    }
    void PreviewItemHeight()
    {   
        if(HeightValue <= MaxHeight - MaxHeight)
        {
            isMaxHeight = false;
        }
        else if(HeightValue >= MaxHeight)
        {
            isMaxHeight = true;
        }

        if (isMaxHeight)
        {
            HeightValue -= HeightSpeed;
        }
        else if (!isMaxHeight)
        {
            HeightValue += HeightSpeed;
        }

        ItemTransform.y = HeightValue;
        PreviewItemTrans.position = ItemTransform;
    }

    void PreviewRotateItem()
    {

        if (RotateValue >= 360)
        {
            RotateValue = 0;
        }
        else
        {
            RotateValue += RotateSpeed;
        }
        ItemRotate = Quaternion.Euler(0, RotateValue, 0);
        PreviewItem.transform.rotation = ItemRotate;
    }
}
