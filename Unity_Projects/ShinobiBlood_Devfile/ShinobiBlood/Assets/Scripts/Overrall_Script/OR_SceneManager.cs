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
    public string SceneName;      //�ǂݍ��ރV�[����
    [SerializeField] private string RandomTips1 = "�X�e�[�W�ɂ���āA����̗͗ʂ͈Ⴄ�I����X�e�[�W�ɍs���΍s���قǁA����̗͂�������Փx���㏸���邼�E�E�E�I"; //Loading Random1 �̎���Tips
    [SerializeField] private string RandomTips2 = "���́A�J�������̓L�����N�^�[�Ă�3�������I���㑝���邩������Ȃ��E�E�E�H"; //Loading Random2 �̎���Tips
    [SerializeField] private string RandomTips3 = "�Q�[���̃��C���L�����N�^�[�ɂ��ā@�@�@�@�@�@�@�@�@�@�E�҂̉ƌn�ɎY�܂ꂽ�����p�t�Ƃ����̂���l���̐ݒ肾�I"; //Loading Random3 �̎���Tips
    //Int
    private int LoadingRandom;

    //GameObject
    [SerializeField] private GameObject LoadingUI;  //���[�f�B���OUI

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
        switch (LoadingRandom)
        {
            case 1:
                Tips.text = RandomTips1;
                break;
            case 2:
                Tips.text = RandomTips2;
                break;
            case 3:
                Tips.text = RandomTips3;
                break;
        }
    }
    void PlayMusic()
    {
        _MusicController.PlayBGMAudio = -1;
    }
    //���̃V�[���ֈړ�����V�X�e��
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

    //���[�f�B���O�V�X�e�� 
    IEnumerator LoadAsyncSceneSystem() 
    {
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        //�V�[�����ǂݏI���܂ő҂�
        while (async.progress < 0.9f)
        {
            ProgressText.text = (async.progress * 100).ToString("0") + "%";
            LoadingBar.fillAmount = async.progress;
            yield return null;
        }
            ProgressText.text = "100%";
            LoadingBar.fillAmount = 1.0f;
            yield return new WaitForSeconds(1.25f); //�҂�����
            async.allowSceneActivation = true;
    }
}
