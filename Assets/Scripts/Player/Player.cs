using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player:MonoBehaviour,IInputListener
{
    PlayerAnimator playerAnimator;
    public bool isGuarding = false;
    [SerializeField] int attackLevels = 4;
    [SerializeField] int _happyLevelMax = 100;
    [SerializeField] List<int> happyBorders = new List<int>();
    [SerializeField] Slider happySlider;

    int nowHappyLevel = 0;



    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        GetComponent<InputSystem>().Register(this);
    }

    void AddHappyLevel(int addValue)
    {
        nowHappyLevel += addValue;
        if (nowHappyLevel > _happyLevelMax)
        {
            nowHappyLevel = _happyLevelMax;
        }
        happySlider.value = nowHappyLevel/(float)_happyLevelMax;
    }

    void SetHappyLevel(int value)
    {
        nowHappyLevel = value;
        happySlider.value = nowHappyLevel/(float)_happyLevelMax;
    }


    public void OnInput(KeyEvent keyEvent)
    {
        switch (keyEvent.Name)
        {
            case InputEventName.Attack:
                //HappyLevelに応じて重み付き確立
                //HappyLevelが超えているボーダーの数と数＋１のどちらかがAttackLevelになる。こえた分だけ＋1の方になる確率が高くなる
                int attackLevel = 0;
                for (int i = 0; i < happyBorders.Count; i++)
                {
                    if (nowHappyLevel > happyBorders[i])
                    {
                        attackLevel++;
                    }
                }
                //超えた分だけ+1になる可能性が高い重み付きランダム抽選
                attackLevel += Random.Range(0, 2);
                playerAnimator.TriggerAttack(attackLevel);
                SetHappyLevel(0);
                break;
            case InputEventName.Happy:
                AddHappyLevel(10);
                playerAnimator.TriggerHappy();
                break;
            case InputEventName.Guard:
                playerAnimator.TriggerGuard();
                break;
        }
    }

}
