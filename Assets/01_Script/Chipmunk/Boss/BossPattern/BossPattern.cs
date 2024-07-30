using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public abstract class BossPattern : MonoBehaviour
{
    protected Sequence _sequence;
    public UnityEvent onPatternEnd;
    protected virtual void Awake() {
        gameObject.SetActive(false);
    }
    public virtual void Pattern(){
        gameObject.SetActive(true);
        Debug.Log("Pattern");
        gameObject.SetActive(true);
        _sequence.AppendCallback(EndPattern);
        _sequence.Play();
    }
    public virtual void EndPattern(){
        Destroy(gameObject);
        onPatternEnd?.Invoke();
    }
}
