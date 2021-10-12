using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainTitle_mainsystem : MonoBehaviour
{
    #region �^�C�g����ʂɕK�v�ȕ�
    //GameObjects
    [SerializeField] private Image GameLogo; // �Q�[���̃��S
    [SerializeField] private Text SubTitle; //�Q�[���̃��S�̉��ɓ���镶��
    [SerializeField] private GameObject SceneManagerObject; //�V�[���}�l�[�W���[��ݒ肵�Ă�I�u�W�F�N�g�Q��
    OR_SceneManager _orSceneManager; //OR_SceneManager
    //Vector&RectTransform
    [SerializeField] private Vector2 LogoPos; //���S�̃|�W�V����
    [SerializeField] private RectTransform RectTrans; //���S�̏ꏊ
    //Float
    [SerializeField] private float BlinkSpeed;      //�_�ő��x
    [SerializeField] private float BlinkTimer;
    [SerializeField] private float LogoMoveHeight; //�ǂ��܂œ�����
    [SerializeField] private float LogoMoveSpeed; //���S���������x
    //Bool
    [SerializeField] private bool isMoveLogo;
    [SerializeField] private bool isLogoMaxHeight;
    [SerializeField] private bool once;
    //SoundObject
    [SerializeField] private SoundController _SoundController;
    [SerializeField] private MusicController _MusicController;
    
    #endregion

    private void Awake()
    {
        _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        _orSceneManager = SceneManagerObject.GetComponent<OR_SceneManager>(); 
        RectTrans = GameLogo.GetComponent<RectTransform>(); 
        LogoPos = RectTrans.anchoredPosition;
        isLogoMaxHeight = false;
        isMoveLogo = true;
        SubTitle.text = "�X�y�[�X�L�[ �������ăX�^�[�g"; //�T�u�^�C�g���̕\��������ݒ� (Def:Press Any Key) 
        Invoke("PlayMusic", 0.1f);
        
    }

    void Update()
    {
        MainTitleAnimationSystem();
        AnyKeyPush();
    }

    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = 4;
    }

    void AnyKeyPush()
    {
        if (once == false) {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _SoundController.PlaySEAudio = 6;
                _orSceneManager.NextSceneLoad();
                once = true;
            }
            else
            {
                _SoundController.PlaySEAudio = -3;
            }
        }
    }

    void MainTitleAnimationSystem() //�^�C�g���̃��S��T�u�^�C�g���̃A�j���[�V�����V�X�e��
    {

        #region ���S���㉺�ɓ����A�j���[�V���� 
        //���S�p (�o�O�C���ς�: 2021/09/26 0:54 - �n� # ���:���� #)
        if (isMoveLogo == true)
        {
            if (isLogoMaxHeight == false)
            {
                LogoPos.y += LogoMoveSpeed;
                if (LogoPos.y >= LogoMoveHeight)
                {
                    isLogoMaxHeight = true;
                }
            }
            if (isLogoMaxHeight == true)
            {
                LogoPos.y -= LogoMoveSpeed;
                if (LogoPos.y <= -LogoMoveHeight)
                {
                    isLogoMaxHeight = false;
                }
            }
        }
        RectTrans.anchoredPosition = LogoPos;
        //���S�p
        #endregion

        #region �T�u�^�C�g�����_�ł���A�j���[�V����
        //�T�u�^�C�g���p (�o�O����: 2021/09/26 1:03 - �n� # ���:���� #)

        SubTitle.color = GetAlphaColor(SubTitle.color);

        Color GetAlphaColor(Color color)
        {
            BlinkTimer += Time.deltaTime * 5.0f * BlinkSpeed;
            color.a = Mathf.Sin(BlinkTimer) * 0.5f + 0.5f;

            return color;
        }
        //�T�u�^�C�g���p
        #endregion
    }
}
