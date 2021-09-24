using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTitle_mainsystem : MonoBehaviour
{
    #region �^�C�g����ʂɕK�v�ȕ�
    //GameObjects
    [SerializeField] private Image GameLogo; // �Q�[���̃��S
    [SerializeField] private Text SubTitle; //�Q�[���̃��S�̉��ɓ���镶��

    //Vector
    Vector3 LogoPos;
    //Float

    //Bool
    public bool isMoveLogo;
    bool isLogoMaxHeight;
    #endregion

    private void Awake()
    {
        isMoveLogo = true;
        SubTitle.text = "�L�[�������ăX�^�[�g"; //�T�u�^�C�g���̕\��������ݒ� (Def:Press Any Key)
    }


    void Update()
    {

        MainTitleAnimationSystem();
    }

    void MainTitleAnimationSystem() //�^�C�g���̃��S��T�u�^�C�g���̃A�j���[�V�����V�X�e��
    {
        LogoPos = GameLogo.transform.position;
        if (isMoveLogo == true) // �o�O������- �C����
        {
            if(isLogoMaxHeight == false)
            {
                LogoPos.y += 0.1f;
                if(LogoPos.y >= 15.0f)
                {
                    isLogoMaxHeight = true;
                }
            }else if(isLogoMaxHeight == true){
                LogoPos.y -= 0.1f;
                if(LogoPos.y <= -15.0f)
                {
                    isLogoMaxHeight = false;
                }
            }
        }
        GameLogo.transform.position = LogoPos;
    }
}
