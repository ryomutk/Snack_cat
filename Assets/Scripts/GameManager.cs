using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour,IEnemyListener,IPlayerListener {
    [SerializeField] EnemyData enemyData;
    Enemy nowEnemy;
    Player player;

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
        player = GetComponentInChildren<Player>();
        GetComponentInChildren<InputSystem>().Register(player);
        nowEnemy.Register(this);
        player.Register(this);
    }

    public void StartBattle()
    {
        nowEnemy.SetEnemy(enemyData);
    }

    public void OnAction(PlayerAction eventName)
    {
        switch (eventName)
        {
            case PlayerAction.attack:
                nowEnemy.TakeDamage(nowEnemy.enemyData.damageList[player.attackLevel]);
                break;
        }
    }


}