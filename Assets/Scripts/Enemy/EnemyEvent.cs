using System;
using UnityEngine;

[Serializable]
public class EnemyEvent
{
    [SerializeField] EnemyEventName eventName;
    [SerializeField] float eventTimeMS;
}