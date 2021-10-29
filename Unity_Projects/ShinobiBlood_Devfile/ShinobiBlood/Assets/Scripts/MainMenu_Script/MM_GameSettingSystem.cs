using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Senz_Program {
    public class MM_GameSettingSystem : MonoBehaviour
    {
        // ゲーム全体適用のオブジェクト
        [SerializeField] private Toggle VSyncToggle;
        [SerializeField] private Toggle FullScreenToggle;
        [SerializeField] private GameObject ResolutionObject;
        [SerializeField] private GameObject ApplyButton;
        [SerializeField] private Dropdown ResolutionList;
        [SerializeField] private Text ResolutionText;
        [SerializeField] private int CheckVsync;
        [SerializeField] private int CheckFullScreen;
        void Start()
        {
            ResolutionList.value = OR_SaveSystem.Instance.SaveData.ResolutionSetting;
            OR_SaveSystem.Instance.Load();
            VSyncToggle.isOn = OR_SaveSystem.Instance.SaveData.VSyncIsEnable;
            FullScreenToggle.isOn = OR_SaveSystem.Instance.SaveData.isFullScreen;
        }
        private void Update()
        {
            if (!OR_SaveSystem.Instance.SaveData.isFullScreen)
            {
                ResolutionText.text = "全画面モードのみ変更可能";
                ResolutionObject.SetActive(false);
            }
            else if (OR_SaveSystem.Instance.SaveData.isFullScreen)
            {
                ResolutionText.text = "解像度設定";
                ResolutionObject.SetActive(true);
            }
        }

        public void VSyncOnValueChange() //VSync
        {
            CheckVsync = VSyncToggle.isOn ? 1 : 0;
            switch (CheckVsync)
            {
                case 1:
                    OR_SaveSystem.Instance.SaveData.VSyncIsEnable = true;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 0:
                    OR_SaveSystem.Instance.SaveData.VSyncIsEnable = false;
                    OR_SaveSystem.Instance.Save();
                    break;
            }
        }
        public void FullScreenOnValueChange()
        {
            CheckFullScreen = FullScreenToggle.isOn ? 1 : 0;
            switch (CheckFullScreen)
            {
                case 1:
                    OR_SaveSystem.Instance.SaveData.isFullScreen = true;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 0:
                    OR_SaveSystem.Instance.SaveData.isFullScreen = false;
                    OR_SaveSystem.Instance.Save();
                    break;
            }
        }
        public void ResolutionSystem()
        {
            switch (ResolutionList.value)
            {
                case 0:     //800x600
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 0;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 800;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 600;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 1:     //1024x768
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 1;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 1024;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 768;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 2:     //1280x960
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 2;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 1280;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 960;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 3:     //1440x792
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 3;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 1440;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 792;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 4:     //1792x1008 
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 4;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 1792;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 1008;
                    OR_SaveSystem.Instance.Save();
                    break;
                case 5:     //1920x1080
                    OR_SaveSystem.Instance.SaveData.ResolutionSetting = 5;
                    OR_SaveSystem.Instance.SaveData.ScreenWidth = 1920;
                    OR_SaveSystem.Instance.SaveData.ScreenHeight = 1080;
                    OR_SaveSystem.Instance.Save();
                    break;
            }
        }

        public void PushApplyResolution()
        {
            QualitySettings.vSyncCount = CheckVsync;
            Screen.fullScreen = OR_SaveSystem.Instance.SaveData.isFullScreen;
            Screen.SetResolution(OR_SaveSystem.Instance.SaveData.ScreenWidth, OR_SaveSystem.Instance.SaveData.ScreenHeight, Screen.fullScreen);
        }
    }
}
