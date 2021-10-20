using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program {
    public class MM_Profile : MonoBehaviour
    {
        [SerializeField] private InputField ChangePlayerName;
        [SerializeField] private Text PlayerName;
        [SerializeField] private Text StatusText;
        private void Awake()
        {
            OR_SaveSystem.Instance.Load();
            PlayerName.text = OR_SaveSystem.Instance.SaveData.PlayerName;
            StatusText.text = "";
        }
        public void PushRename()
        {
            if (ChangePlayerName.text.Length <= 2) //エラートラップ 文字数
            {
                StatusText.color = new Color(1.0f, 0.0f, 0.0f);
                StatusText.text = "エラー: 文字数が少なすぎます 2文字を超える文字数を入力してください";
                Invoke("DeleteMessage", 2.0f);
                return;
            }
            if (ChangePlayerName.text == PlayerName.text || ChangePlayerName.text == OR_SaveSystem.Instance.SaveData.PlayerName) //エラートラップ 同名
            {
                StatusText.color = new Color(1.0f, 0.0f, 0.0f);
                StatusText.text = "エラー: 同じ名前は設定出来ません";
                Invoke("DeleteMessage", 2.0f);
                return;
            }
            OR_SaveSystem.Instance.SaveData.PlayerName = ChangePlayerName.text;
            OR_SaveSystem.Instance.Save();
            PlayerName.text = OR_SaveSystem.Instance.SaveData.PlayerName;
            StatusText.color = new Color(0.0f, 1.0f, 0.0f);
            StatusText.text = "名前が変更されました";
            Invoke("DeleteMessage", 2.0f);
        }
        void DeleteMessage()
        {
            StatusText.text = "";
        }
    }
}
