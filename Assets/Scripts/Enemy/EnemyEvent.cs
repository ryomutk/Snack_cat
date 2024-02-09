using System;
using UnityEngine;

[Serializable]
public struct EnemyEvent
{
    [SerializeField] public EnemyEventName eventName;
    [SerializeField] public float eventTimeMS;
}