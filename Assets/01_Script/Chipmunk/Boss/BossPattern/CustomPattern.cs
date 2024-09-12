using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
[Serializable]
public struct CustomPatternItem
{
    public BossPattern pattern;
    public float delay;
}
public class CustomPattern : BossPattern
{
    protected override void Awake()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pattern();
        }
    }
    [SerializeField] List<CustomPatternItem> _patternList;
    public override void Pattern()
    {
        _sequence = DOTween.Sequence();
        _patternList.ForEach(item =>
        {
            BossPattern pattern;
            if (item.pattern.gameObject.scene.rootCount == 0)
            {
                pattern = Instantiate(item.pattern);
            }
            else
            {
                pattern = item.pattern;
            }
            _sequence.AppendInterval(item.delay);
            _sequence.AppendCallback(pattern.Pattern);
        });
        _sequence.Play();
        base.Pattern();
    }
    public override void EndPattern()
    {
        onPatternEnd?.Invoke();
    }
}
