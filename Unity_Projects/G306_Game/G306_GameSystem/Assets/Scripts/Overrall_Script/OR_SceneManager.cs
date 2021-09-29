using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OR_SceneManager : MonoBehaviour
{
    //ASync
    private AsyncOperation async;           //AsyncOperation

    //String
    [SerializeField] private string SceneName;      //�ǂݍ��ރV�[����
    [SerializeField] private string RandomTips1; //Loading Random1 �̎���Tips
    [SerializeField] private string RandomTips2; //Loading Random2 �̎���Tips
    [SerializeField] private string RandomTips3; //Loading Random3 �̎���Tips
    //Int
    private int LoadingRandom;

    //GameObject
    [SerializeField] private GameObject LoadingUI;  //���[�f�B���OUI
    [SerializeField] private GameObject LoadingBG1; //���[�f�B���O Random1 �̎��̔w�i
    [SerializeField] private GameObject LoadingBG2; //���[�f�B���O Random2 �̎��̔w�i
    [SerializeField] private GameObject LoadingBG3; //���[�f�B���O Random3 �̎��̔w�i

    //Image
    [SerializeField] private Image LoadingBar;      //NowLoading�̃v���O���X�o�[�̎w��

    //Text
    [SerializeField] private Text ProgressText;     //�v���O���X�e�L�X�g
    [SerializeField] private Text Tips;             //Tips�e�L�X�g

    //MusicObject
    [SerializeField] private MusicController _MusicController;
    private void Awake()
    {
        _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
        LoadingRandom = Random.Range(1, 4); //�����_������ 1 - 3
        if (LoadingRandom == 1)
        {
            LoadingBG1.SetActive(true);
            LoadingBG2.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = RandomTips1;
        }
        if (LoadingRandom == 2)
        {
            LoadingBG2.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG3.SetActive(false);
            Tips.text = RandomTips2;
        }
        if (LoadingRandom == 3)
        {
            LoadingBG3.SetActive(true);
            LoadingBG1.SetActive(false);
            LoadingBG2.SetActive(false);
            Tips.text = RandomTips3;
        }
    }
    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = -1;
    }
    //���̃V�[���ֈړ�����V�X�e�� (�o�O����: 2021/09/26 1:26 - �n� # ���:���� #)
    //���̃V�[���ֈړ��������Ƃ��� NextSceneLoad()�֐������g�p���������B
    //�� �g���� ��
    //1 -  ���̃V�[���ɋ�̃Q�[���I�u�W�F�N�g��z�u���A���̃X�N���v�g��ݒ肵�܂��B
    //2 -  SceneName�ɓǂݍ��܂������V�[���̖��O����͂��܂��B
    //3 -  ���̃I�u�W�F�N�g���炱�̃X�N���v�g��ǂݍ���� �C�ӂ̃^�C�~���O�� NextSceneLoad�����s���܂�
    public void NextSceneLoad()
    {
        LoadingUI.SetActive(true);
        StartCoroutine("LoadAsyncSceneSystem");
    }

    //���[�f�B���O�V�X�e�� (�o�O����: 2021/09/26 1:30 - �n� # ���:���� #)
    IEnumerator LoadAsyncSceneSystem() 
    {
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        //�V�[�����ǂݏI���܂ő҂�
        while (async.progress < 0.9f)
        {
            ProgressText.text = (async.progress * 100) + "%";
            LoadingBar.fillAmount = async.progress;
            yield return null;
        }
            ProgressText.text = "100%";
            LoadingBar.fillAmount = 1.0f;
            yield return new WaitForSeconds(1.5f); //�҂�����
            async.allowSceneActivation = true;
    }
}
