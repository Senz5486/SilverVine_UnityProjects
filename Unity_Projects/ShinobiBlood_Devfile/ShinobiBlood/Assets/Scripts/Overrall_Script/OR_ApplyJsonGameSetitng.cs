using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Senz_Program
{
    public class OR_ApplyJsonGameSetitng : MonoBehaviour
    {
        [SerializeField] private int Enable;
        void Start()
        {
            if (OR_SaveSystem.Instance.SaveData.VSyncIsEnable)
            {
                Enable = 1;
                QualitySettings.vSyncCount = Enable;
            }
            else if (!OR_SaveSystem.Instance.SaveData.VSyncIsEnable)
            {
                Enable = 0;
                QualitySettings.vSyncCount = Enable;
            }
        }
        private void Update()
        {
            if (OR_SaveSystem.Instance.SaveData.VSyncIsEnable)
            {
                Enable = 1;
                QualitySettings.vSyncCount = Enable;
            }
            else if (!OR_SaveSystem.Instance.SaveData.VSyncIsEnable)
            {
                Enable = 0;
                QualitySettings.vSyncCount = Enable;
            }
        }
    }
}
