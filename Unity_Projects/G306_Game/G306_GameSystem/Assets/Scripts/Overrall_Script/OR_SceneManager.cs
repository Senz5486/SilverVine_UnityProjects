using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OR_SceneManager : MonoBehaviour
{
    private AsyncOperation async;           //AsyncOperation
    [SerializeField] private string SceneName;      //�ǂݍ��ރV�[����
    [SerializeField] private GameObject LoadingUI;  //���[�f�B���OUI
    [SerializeField] private Image LoadingBar;      //NowLoading�̃v���O���X�o�[�̎w��

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
        //�V�[�����ǂݏI���܂ő҂�
        while (!async.isDone)
        {
            var ProgressValue = Mathf.Clamp01(async.progress / 0.9f);
            LoadingBar.fillAmount = ProgressValue;
            yield return null;
        }
    }
}
