using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler
{
    public ItemScriptableObject itemScriptableObject;
    public int index;
    public UIOnHoverItem onHoverItem;
    public GameObject canvas;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverItem.transform.parent = canvas.transform;
        onHoverItem.gameObject.SetActive(true);
        string description = "";
        foreach(ItemInfo itemInfo in itemScriptableObject.itemInfos)
        {
            description += "+" + "<color=" + "#4A58FF" + ">" + itemInfo.value + "</color>" + " " + itemInfo.name + "<br>";
        }
        onHoverItem.SetUI(itemScriptableObject.itemShopSprite[0], itemScriptableObject.itemName, description);
    }
}
