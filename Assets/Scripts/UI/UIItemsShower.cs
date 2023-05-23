using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemsShower : MonoBehaviour
{
    [SerializeField] GameObject uIItemParent;
    [SerializeField] UIShortUIElement template;
    [SerializeField] GameObject mouseOverTemplate;
    [SerializeField] GameObject canvas;
    [SerializeField] bool isWeapon;
    private List<GameObject> uIItems = new List<GameObject>();

    float itemPosX;
    float itemPosY;
    // Start is called before the first frame update
    void Start()
    {
        if (isWeapon)
        {
            showItems(GlobalController.Instance.weapons);
        }
        else
        {
            showItems(GlobalController.Instance.items.ToArray());
        }
    }

    public void showItems(ItemScriptableObject[] items)
    {
        int index = 0;
        itemPosX = template.parent.gameObject.transform.position.x;
        itemPosY = template.parent.gameObject.transform.position.y;
        foreach (GameObject uItem in uIItems)
        {
            Destroy(uItem);
        }
        uIItems = new List<GameObject>();
        foreach (ItemScriptableObject item in items)
        {
            if (item != null)
            {
                uIItems.Add(Instantiate(template.parent.gameObject, uIItemParent.transform));
                UIItem uIItem = uIItems[index].GetComponent<UIItem>();
                uIItem.ItemScriptableObject = item;
                uIItem.index = index;
                uIItems[index].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.itemName[0] + "" + item.itemName[item.itemName.Length - 1];
                uIItems[index].SetActive(true);
                RectTransform rectTransform = uIItems[index].GetComponent<RectTransform>();
                uIItems[index].transform.position = new Vector3(itemPosX, itemPosY, 0);
                itemPosX += rectTransform.rect.width + 5;
                if (index == 2)
                {
                    itemPosX = template.parent.gameObject.transform.position.x;
                    itemPosY = template.parent.gameObject.transform.position.y;
                    itemPosY -= rectTransform.rect.height + 5;
                }
                index++;
            }
        }
    }

}
