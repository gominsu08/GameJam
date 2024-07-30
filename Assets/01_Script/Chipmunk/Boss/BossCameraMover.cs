using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossCameraMover : MonoBehaviour
{
    [SerializeField] Ease _ease = Ease.Linear;
    [SerializeField] float _duration = 0.5f;
    private Vector3 _startPos;
    private void Awake()
    {
        _startPos = transform.position;
    }
    public void Move(Vector2 pos)
    {
        Vector2 movePos = (pos + ((Vector2)_startPos)) / 2;
        transform.DOMove(new Vector3(movePos.x, movePos.y, _startPos.z), _duration).SetEase(_ease);
    }
}
