using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour,IEnemyListener {
    [SerializeField] EnemyData enemyData;
    Enemy nowEnemy;

    public void OnEvent(EnemyEventName eventName)
    {
        switch (eventName)
        {
            case EnemyEventName.yobi:
                break;
            case EnemyEventName.attack:
                break;
        }
    }

    void Start()
    {
        nowEnemy = GetComponentInChildren<Enemy>();
        nowEnemy.Register(this);
    }

    public void StartBattle()
    {
        nowEnemy.SetEnemy(enemyData);
    }


}