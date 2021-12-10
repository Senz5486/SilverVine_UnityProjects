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
        [SerializeField] private Dropdown Quality;
        [SerializeField] private Text ResolutionText;
        [SerializeField] private int CheckVsync;
        [SerializeField] private Toggle FullScreen;
        [SerializeField] private Toggle Window;
        [SerializeField] private Toggle FullScreenWindow;

        List<string> Res = new List<string>();
        int Index;
        [SerializeField] int getQualityValue;
        [SerializeField]int CurrentQualityLevel;
        void Start()
        {
            Quality.value = OR_SaveSystem.Instance.SaveData.QualitySetting;
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                Res.Add(Screen.resolutions[i].ToString());

                if (Screen.resolutions[i].width == Screen.currentResolution.width &&
                    Screen.resolutions[i].height == Screen.currentResolution.height &&
                    Screen.resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                {
                    Index = i;
                }
            }

            

            switch (Screen.fullScreenMode)
            {
                case FullScreenMode.ExclusiveFullScreen:
                    FullScreen.isOn = true;
                    break;
                case FullScreenMode.FullScreenWindow:

                    break;
                case FullScreenMode.MaximizedWindow:
                    FullScreenWindow.isOn = true;
                    break;
                case FullScreenMode.Windowed:
                    Window.isOn = true;
                    break;
                default:
                    break;
            }
            ResolutionList.AddOptions(Res);
            ResolutionList.value = Index;
            OR_SaveSystem.Instance.Load();
            VSyncToggle.isOn = OR_SaveSystem.Instance.SaveData.VSyncIsEnable;
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

        public void QualityValueGet(int Value)
        {
            Value = Quality.value;
            getQualityValue = Value;
        }

        public void PushApplyResolution()
        {
            QualitySettings.SetQualityLevel(getQualityValue, true);
            CurrentQualityLevel = QualitySettings.GetQualityLevel();
            OR_SaveSystem.Instance.SaveData.QualitySetting = getQualityValue;
            switch (CurrentQualityLevel)
            {
                case 0:
                    Debug.Log("画質設定が 最低 に設定されました");
                    break;
                case 1:
                    Debug.Log("画質設定が 低 に設定されました");
                    break;
                case 2:
                    Debug.Log("画質設定が ふつう に設定されました");
                    break;
                case 3:
                    Debug.Log("画質設定が 高 に設定されました");
                    break;
                case 4:
                    Debug.Log("画質設定が 最高 に設定されました");
                    break;
                case 5:
                    Debug.Log("画質設定が ウルトラ に設定されました");
                    break;
            }
            FullScreenMode fullScreenMode = FullScreenMode.Windowed;
            if (FullScreen.isOn)
            {
                fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else if (FullScreenWindow.isOn)
            {
                fullScreenMode = FullScreenMode.MaximizedWindow;
            }

            QualitySettings.vSyncCount = CheckVsync;

            Screen.SetResolution(int.Parse(Res[ResolutionList.value].Split(' ')[0]), int.Parse(Res[ResolutionList.value].Split(' ')[2]), fullScreenMode);

            OR_SaveSystem.Instance.Save();
        }
    }
}
