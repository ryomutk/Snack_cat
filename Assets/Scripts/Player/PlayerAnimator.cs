using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Video;
using System.Collections.Generic;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]TMP_Text sampleTextPref;
    ObjectPool<TMP_Text> sampleTextPool; 
    [SerializeField]List<VideoClip> attackClips;
    [SerializeField]VideoClip guardClip;
    VideoPlayer videoPlayer;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        sampleTextPool = new ObjectPool<TMP_Text>(sampleTextPref, 5, transform.parent);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.clear;
        videoPlayer.Stop();
    }

    private void Update()
    {
    }


    public void TriggerHappy()
    {
        //sampleTextをHappyにして、上へ浮かびながら明るい色で点滅した後、フェードアウト
        var sampleText = sampleTextPool.GetObject();
        sampleText.text = "Happy";
        var startPosition = sampleText.transform.localPosition;

        sampleText.transform.DOLocalMoveY(1.0f, 0.5f).SetEase(Ease.OutQuart);
        sampleText.DOColor(Color.yellow, 0.5f).SetLoops(6, LoopType.Yoyo).SetEase(Ease.OutQuart);
        sampleText.DOFade(0, 0.5f).SetDelay(3.0f).onComplete += () =>
        {
            sampleText.transform.localPosition = startPosition;
            sampleText.color = Color.white;
            sampleText.text = "Hello";
            sampleText.gameObject.SetActive(false);
        };
    }

    public void TriggerAttack(int attackLevel)
    {
        //攻撃アニメーション
        //videoClipsの中からAttackLevelのものをVideoPlayerにセットして再生
        videoPlayer.clip = attackClips[attackLevel];
        _spriteRenderer.DOFade(1, 0.1f).onComplete += () =>
        {
            videoPlayer.DOPlay();
            _spriteRenderer.DOFade(0, 2f).SetDelay(3f).onComplete += () =>
            {
                videoPlayer.Stop();
            };
        };
    }

    public void TriggerGuard()
    {
        //Guardアニメーション
        //guardClipをVideoPlayerにセットして再生
        videoPlayer.clip = guardClip;
        _spriteRenderer.DOFade(1, 0.1f).onComplete += () =>
        {
            videoPlayer.DOPlay();
            _spriteRenderer.DOFade(0, 2f).SetDelay(3f).onComplete += () =>
            {
                videoPlayer.Stop();
            };
        };
    }
}