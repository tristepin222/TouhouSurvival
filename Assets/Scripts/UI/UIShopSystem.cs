using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopSystem : MonoBehaviour
{
    [SerializeField] UIShopElement[] uIShopItems;

    private ItemScriptableObject[] pool;
    // Start is called before the first frame update
    private void Start()
    {
        ShopSystem shopSystem = new ShopSystem();
        shopSystem.GetItems();
        pool = shopSystem.CheckWeight();
        StartCoroutine(ShowUpgrades(pool));
    }
    private IEnumerator ShowUpgrades(ItemScriptableObject[] selectedPool)
    {
        int i = 0;
        foreach (ItemScriptableObject itemScriptableObject in selectedPool)
        {
            uIShopItems[i].imageSprite.sprite = itemScriptableObject.itemShopSprite[0];
            uIShopItems[i].name.text = itemScriptableObject.itemName;
            uIShopItems[i].imageSprite.rectTransform.localScale = new Vector2(itemScriptableObject.scaleX, itemScriptableObject.scaleY);
            uIShopItems[i].subName.text = itemScriptableObject.itemType;
            uIShopItems[i].moneyAmount.text = itemScriptableObject.cost.ToString();
            uIShopItems[i].stats.text = "";
            foreach (ItemInfo itemInfo in itemScriptableObject.itemInfos)
            {
                uIShopItems[i].stats.text += "+" + "<color=" + "#4A58FF" + ">" + itemInfo.damageValue + "</color>" + " " + itemInfo.damageInfo + "<br>";
            }

            i++;
        }
        yield return 0;
    }
}
