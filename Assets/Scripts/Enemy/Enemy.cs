using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] EnemyData _enemyData;
    [SerializeField] Slider hpBar;

    int _nowHealth;
    public int nowHealth
    {
        get { return _nowHealth; }
        private set { _nowHealth = value; }
    }

    void ResetHealth()
    {
        nowHealth = _enemyData.maxHealth;
    }

    void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        nowHealth -= damage;
        hpBar.value = (float)nowHealth / _enemyData.maxHealth;
    }
}
