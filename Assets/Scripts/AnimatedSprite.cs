using UnityEngine;
using UnityEngine.Video;


public class AnimatedSprite:MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    VideoPlayer _videoPlayer;
    
    public SpriteRenderer spriteRenderer{
        get{
            if(_spriteRenderer == null){
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }

    public VideoPlayer videoPlayer{
        get{
            if(_videoPlayer == null){
                _videoPlayer = GetComponent<VideoPlayer>();
            }
            return _videoPlayer;
        }
    }

}