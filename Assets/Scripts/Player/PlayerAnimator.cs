using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Video;
using System.Collections.Generic;
using System;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]List<VideoClip> attackClips;
    [SerializeField]VideoClip guardClip;
    [SerializeField] AnimatedSprite animatedSpritePref;
    [SerializeField] VideoClip happyClip;


    ObjectPool<AnimatedSprite> animationPool;
    

    private void Awake()
    {
        animationPool = new ObjectPool<AnimatedSprite>(animatedSpritePref, 10, transform);
    }


    public void TriggerHappy()
    {
        var happyAnimation = animationPool.GetObject();
        //sampleTextをHappyにして、上へ浮かびながら明るい色で点滅した後、フェードアウト
        var startPosition = happyAnimation.spriteRenderer.transform.localPosition;


        happyAnimation.videoPlayer.clip = happyClip;
        happyAnimation.videoPlayer.Play();
        
        happyAnimation.spriteRenderer.transform.DOLocalMoveY(1.0f, 0.5f).SetEase(Ease.OutQuart);
        happyAnimation.spriteRenderer.DOColor(Color.yellow, 0.5f).SetLoops(6, LoopType.Yoyo).SetEase(Ease.OutQuart);
        happyAnimation.spriteRenderer.DOFade(0, 0.5f).SetDelay(3.0f).onComplete += () =>
        {
            happyAnimation.spriteRenderer.transform.localPosition = startPosition;
            happyAnimation.spriteRenderer.color = Color.white;
            happyAnimation.videoPlayer.Stop();
            happyAnimation.gameObject.SetActive(false);
        };
    }

    public void TriggerAttack(int attackLevel)
    {
        //攻撃アニメーション
        //videoClipsの中からAttackLevelのものをVideoPlayerにセットして再生
        var animatorSprite = animationPool.GetObject();

        animatorSprite.videoPlayer.clip = attackClips[Math.Min(attackLevel, attackClips.Count - 1)];
        animatorSprite.spriteRenderer.color = Color.white;
        animatorSprite.spriteRenderer.DOFade(1, 0.1f).onComplete += () =>
        {
            animatorSprite.videoPlayer.DOPlay();
            animatorSprite.spriteRenderer.DOFade(0, 2f).SetDelay(3f).onComplete += () =>
            {
                animatorSprite.videoPlayer.Stop();
                animatorSprite.gameObject.SetActive(false);
            };
        };
    }

    public void TriggerGuard()
    {
        //Guardアニメーション
        //guardClipをVideoPlayerにセットして再生
        var guardAnimation = animationPool.GetObject();
        guardAnimation.videoPlayer.clip = guardClip;
        guardAnimation.spriteRenderer.color = Color.white;
        guardAnimation.spriteRenderer.DOFade(1, 0.1f).onComplete += () =>
        {
            guardAnimation.videoPlayer.DOPlay();
            guardAnimation.spriteRenderer.DOFade(0, 2f).SetDelay(3f).onComplete += () =>
            {
                guardAnimation.videoPlayer.Stop();
                guardAnimation.gameObject.SetActive(false);
            };
        };
    }
}