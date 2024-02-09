using UnityEngine;
using DG.Tweening;

public class EnemyAnimator:MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Color yobiColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TriggerYobi()
    {
        //赤い点滅3回
        spriteRenderer.DOColor(yobiColor, 0.1f).SetLoops(6, LoopType.Yoyo).SetEase(Ease.OutQuart);
    }

    public void TriggerAttack()
    {
        //攻撃アニメーション
        //左に素早く動いて戻る
        transform.DOMoveX(transform.position.x - 0.5f, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuart);
    }
}