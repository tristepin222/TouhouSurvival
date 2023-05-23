using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler
{
    public ItemScriptableObject ItemScriptableObject;
    public int index;
    public UIOnHoverItem onHoverItem;
    public GameObject canvas;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverItem.transform.parent = canvas.transform;
        onHoverItem.gameObject.SetActive(true);
        onHoverItem.SetUI(ItemScriptableObject.itemShopSprite[0], ItemScriptableObject.itemName);
    }
}
