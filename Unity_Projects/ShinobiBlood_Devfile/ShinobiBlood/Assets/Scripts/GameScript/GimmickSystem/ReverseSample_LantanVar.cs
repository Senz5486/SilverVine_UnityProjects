using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSample_LantanVar : MonoBehaviour
{
    [SerializeField] GameObject revarseArea;
    bool isReverse;
    [SerializeField] GameObject[] Lantan;
    LantanObject[] LantanObject;

    // Start is called before the first frame update
    void Start()
    {
        LantanObject = new LantanObject[Lantan.Length];
        for(int i = 0; i < Lantan.Length;i++)
        {
            LantanObject[i] = Lantan[i].gameObject.GetComponent<LantanObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool clearFlag = true;
        for(int i = 0; i < Lantan.Length; i++)
        {
            if (!LantanObject[i].GetFire())
            {
                clearFlag = false;
                break;
            }     
        }
        if(clearFlag)
        {
            revarseArea.transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }
}
