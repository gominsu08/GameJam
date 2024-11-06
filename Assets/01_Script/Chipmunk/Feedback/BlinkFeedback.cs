using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFeedback : Feedback
{
   [SerializeField] private SpriteRenderer _targetRenderer;
   [SerializeField] private float _flashTime = 0.1f;
   Material _targetMat;

   private readonly int _isHitHash = Shader.PropertyToID("_IsHit");
   private void Awake() {
    // 스프라이트 렌더러에 있는 메티리얼을 가져옴
    _targetMat = _targetRenderer.material; 
   }

    public override void PlayFeedback()
    {
        _targetMat.SetInt(_isHitHash, 1);
        StartCoroutine(DelayBlink());
    }
    private IEnumerator DelayBlink(){
        yield return new WaitForSeconds(_flashTime);
        _targetMat.SetInt(_isHitHash, 0);
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
        _targetMat.SetInt(_isHitHash, 0);
    }
}
