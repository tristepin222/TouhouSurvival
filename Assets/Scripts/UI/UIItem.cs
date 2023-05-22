using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler
{
    public ItemScriptableObject ItemScriptableObject;
    public GameObject canvas;
    public GameObject template;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Instantiate(template, canvas.transform);
        template.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition / canvas.transform.localScale.x;
    }
}
