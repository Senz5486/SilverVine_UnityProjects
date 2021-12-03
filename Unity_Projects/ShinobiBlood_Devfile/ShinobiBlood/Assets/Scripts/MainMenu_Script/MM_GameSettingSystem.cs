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
        [SerializeField] private Toggle FullScreen;
        [SerializeField] private Toggle Window;
        [SerializeField] private Toggle FullScreenWindow;

        List<string> Res = new List<string>();
        int Index;

        void Start()
        {
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

        public void PushApplyResolution()
        {
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
        }
    }
}
