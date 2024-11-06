using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ReCoilFeedback : Feedback
{
    [SerializeField] private Transform _targetTrm;
    [SerializeField] private float _recoilAmout = 0.15f;
    [SerializeField] private float _recoilTime = 0.05f;
    private Vector3 _initPos;
    private Tween _recoilTween;
    private void Awake() {
        _initPos = _targetTrm.localPosition; //처음 시작시 로컬 위치 저장
    }
    public override void PlayFeedback()
    {
        float targetX = _initPos.x - _recoilAmout;
        _recoilTween = _targetTrm.DOLocalMoveX(targetX, _recoilTime).SetEase(Ease.OutQuint).SetLoops(2, LoopType.Yoyo);
    }

    public override void StopFeedback()
    {
        if(_recoilTween != null && _recoilTween.IsActive()){
            _recoilTween.Kill();
            _targetTrm.localPosition = _initPos;
        }
    }
}
