using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData", order = 1)]
public class EnemyData:ScriptableObject
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] List<EnemyEvent> _eventTimeLine;
    [SerializeField] List<int> _damageList;

    public int maxHealth
    {
        get { return _maxHealth; }
    }


    public List<EnemyEvent> eventTimeLine
    {
        get { return _eventTimeLine; }
    }

    public List<int> damageList
    {
        get { return _damageList; }
    }

    
}