using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MG_HealthSystem : MonoBehaviour
{
    //public float
    public float CurrentHealth; //Default:100
    public float MaxHealth;     //Default:100

    public float MinusTime;     //1.0f�Ȃ�1�b���Ƃɑ̗͂�����
    public float MinusHealth;   //MinusTime���Ɍ���̗͗�
    //public bool
    public bool isStart;        //�X�e�[�W���X�^�[�g�������ǂ���
    public bool isDead;

    //float
    [SerializeField] private float MinusTimer;

    //Image
    [SerializeField] private Image HealthRedBar;
    [SerializeField] private Image HealthPurpleBar;

    //Text
    [SerializeField] private Text HealthPersentText;
    
    //Tween
    private Tween HealthPurpleTween;
    private void Awake()
    {
        CurrentHealth = 100;
        MaxHealth = 100;
    }
    void Update()
    {
        PerSecMinusSystem();
        
    }

    void PerSecMinusSystem()
    {
        if (isStart == true)
        {
            LimitHealthControll();
            MinusTimer += Time.deltaTime;
            if (MinusTimer >= MinusTime)
            {
                CurrentHealth -= MinusHealth;
                HealthBarUpdate(MinusHealth);
                MinusTimer = 0;
            }
        }
    }
    public void HealthBarUpdate(float reducationValue, float time = 0.5f)
    {
        var ValueFrom = CurrentHealth / MaxHealth;
        var ValueTo = (CurrentHealth - reducationValue) / MaxHealth;
        HealthPersentText.text = (ValueFrom * 100).ToString() + "%";

        //�ԃQ�[�W�̏펞����
        HealthRedBar.fillAmount = ValueTo;

        if (HealthPurpleTween != null)
        {
            HealthPurpleTween.Kill();
        }

        //���Q�[�W�̌���
        HealthPurpleTween = DOTween.To(() => ValueFrom, x => { HealthPurpleBar.fillAmount = x; }, ValueTo, time);
    }
    public void LimitHealthControll()
    {
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            HealthPersentText.text = "�Q�[���I�[�o�[";
            isDead = true;
            return;
        }
        else
        {
            isDead = false;
        }
    }
}