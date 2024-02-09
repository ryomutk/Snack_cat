using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] EnemyData _enemyData;
    [SerializeField] Slider hpBar;

    public EnemyData enemyData
    {
        get { return _enemyData; }
    }
    List<IEnemyListener> _listeners = new List<IEnemyListener>();
    public void Register(IEnemyListener listener)
    {
        if (!_listeners.Contains(listener))
        {
            _listeners.Add(listener);
        }
    }

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

    public void SetEnemy(EnemyData data)
    {
        _enemyData = data;
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        nowHealth -= damage;
        hpBar.value = (float)nowHealth / _enemyData.maxHealth;
    }

    IEnumerator EventSequencer()
    {
        foreach (var e in _enemyData.eventTimeLine)
        {
            yield return new WaitForSeconds(e.eventTimeMS / 1000);
            foreach (var l in _listeners)
            {
                l.OnEvent(e.eventName);
            }
        }
    }

    public void StartMoving()
    {
        StartCoroutine(EventSequencer());
    }
}
