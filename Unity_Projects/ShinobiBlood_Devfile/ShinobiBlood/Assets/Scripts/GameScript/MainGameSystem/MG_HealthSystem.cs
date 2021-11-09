using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MG_HealthSystem : MonoBehaviour
{
    //public float
    private float _CurrentHealth; //Default:100
    private float _MaxHealth;     //Default:100
    private float _MinusTime;     //1.0fなら1秒ごとに体力が減る
    private float _MinusHealth;   //MinusTime毎に減る体力量

    public float CurrentHealth { get { return _CurrentHealth; } set { _CurrentHealth = value; } }
    public float MaxHealth { get { return _MaxHealth; } set { _MaxHealth = value; } }
    public float MinusTime { get { return _MinusTime; } set { _MinusTime = value; } }
    public float MinusHealth { get { return _MinusHealth; } set { _MinusHealth = value; } }
    //public bool
    private bool _isStart;        //ステージがスタートしたかどうか
    private bool _isDead;

    public bool isStart { get { return _isStart; } set { _isStart = value; } }
    public bool isDead { get { return _isDead; } set { _isDead = value; } }

    //float
    [SerializeField] private float MinusTimer;

    //Image
    [SerializeField] private Image HealthRedBar;
    [SerializeField] private Image HealthPurpleBar;

    //無敵時間用
    private bool isInvincible;
    private float invincibleTime;
    private GameObject playerMesh;
    private bool isPlayerActive;

    //Text

    //Tween
    private Tween HealthPurpleTween;
    private void Awake()
    {
        _MinusTime = 1.0f;
        _CurrentHealth = 100;
        _MaxHealth = 100;
        isInvincible = false;
        invincibleTime = 0;
        playerMesh = GameObject.Find("Player_MESH");
    }
    void Update()
    {
        PerSecMinusSystem();
        invincibleTime -= Time.deltaTime;

        if(invincibleTime <= 0) 
        { 
            isInvincible = false; 
        }
        else
        {
            isPlayerActive = !isPlayerActive;
            playerMesh.SetActive(isPlayerActive);
        }
    }

    void PerSecMinusSystem()
    {
        if (_isStart == true)
        {
            LimitHealthControll();
            MinusTimer += Time.deltaTime;
            if (MinusTimer >= _MinusTime)
            {
                HealthBarUpdate(_MinusHealth);
                _CurrentHealth -= _MinusHealth;
                MinusTimer = 0;
            }
        }
    }
    public void TokenDamage(float Damage)
    {
        if (isInvincible) { return; }

        isInvincible = true;
        invincibleTime = 1;
        HealthBarUpdate(Damage);
        _CurrentHealth -= Damage;
    }
    public void HealthBarUpdate(float reducationValue, float time = 0.5f)
    {
        var ValueFrom = _CurrentHealth / _MaxHealth;
        var ValueTo = (_CurrentHealth - reducationValue) / _MaxHealth;

        //赤ゲージの常時減少
        HealthRedBar.fillAmount = ValueTo;

        if (HealthPurpleTween != null)
        {
            HealthPurpleTween.Kill();
        }

        //紫ゲージの減少
        HealthPurpleTween = DOTween.To(() => ValueFrom, x => { HealthPurpleBar.fillAmount = x; }, ValueTo, time);
    }

    public void LimitHealthControll()
    {
        if(_CurrentHealth <= 0)
        {
            _CurrentHealth = 0;
            _isDead = true;
            return;
        }
        else
        {
            _isDead = false;
        }
    }
}
