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
            if (ChangePlayerName.text.Length <= 2) //�G���[�g���b�v ������
            {
                StatusText.color = new Color(1.0f, 0.0f, 0.0f);
                StatusText.text = "�G���[: �����������Ȃ����܂� 2�����𒴂��镶��������͂��Ă�������";
                Invoke("DeleteMessage", 2.0f);
                return;
            }
            if (ChangePlayerName.text == PlayerName.text || ChangePlayerName.text == OR_SaveSystem.Instance.SaveData.PlayerName) //�G���[�g���b�v ����
            {
                StatusText.color = new Color(1.0f, 0.0f, 0.0f);
                StatusText.text = "�G���[: �������O�͐ݒ�o���܂���";
                Invoke("DeleteMessage", 2.0f);
                return;
            }
            OR_SaveSystem.Instance.SaveData.PlayerName = ChangePlayerName.text;
            OR_SaveSystem.Instance.Save();
            PlayerName.text = OR_SaveSystem.Instance.SaveData.PlayerName;
            StatusText.color = new Color(0.0f, 1.0f, 0.0f);
            StatusText.text = "���O���ύX����܂���";
            Invoke("DeleteMessage", 2.0f);
        }
        void DeleteMessage()
        {
            StatusText.text = "";
        }
    }
}
