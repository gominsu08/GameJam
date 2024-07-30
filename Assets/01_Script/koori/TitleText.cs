using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image selectIcon;
    [SerializeField] private float textImpact;

    private TMP_Text text;

    private void Start()
    {
        selectIcon.gameObject.SetActive(false);
        text = GetComponentInChildren<TMP_Text>();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        selectIcon.gameObject.SetActive(false);
        text.fontSize = text.fontSize / textImpact;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectIcon.gameObject.SetActive(true);
        text.fontSize = text.fontSize * textImpact;
    }
}
