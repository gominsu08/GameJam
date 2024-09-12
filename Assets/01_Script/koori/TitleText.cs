using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _selectIcon;
    [SerializeField] private float _textImpact;

    private bool _isActive = false;

    private TMP_Text text;

    private void Start()
    {
        _selectIcon.gameObject.SetActive(false);
        text = GetComponentInChildren<TMP_Text>();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _isActive = false;
        _selectIcon.gameObject.SetActive(false);
        text.fontSize = text.fontSize / _textImpact;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isActive)
        {
            SFXPlayer.Instance.PlayEnter();
            _isActive = true;
        }
        _selectIcon.gameObject.SetActive(true);
        text.fontSize = text.fontSize * _textImpact;
        
    }
}
