using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIShopSystem : MonoBehaviour
{
    [SerializeField] UIShopElement[] uIShopItems;
    [SerializeField] RarityScriptableObject rarityScriptableObject;
    [SerializeField] TextMeshProUGUI currentCoinAmountText;
    [SerializeField] TextMeshProUGUI rerollCoinAmountText;
    private ItemScriptableObject[] pool;
    ShopSystem shopSystem;
    // Start is called before the first frame update
    private void Start()
    {
        shopSystem = new ShopSystem();
        pool = shopSystem.CheckWeight();
        StartCoroutine(ShowUpgrades(pool));
        UpdateCoinAmount();
        rerollCoinAmountText.text = (GlobalController.Instance.coin * 5).ToString();
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
            switch (itemScriptableObject.rarity)
            {
                case 0:
                    uIShopItems[i].backGround.color = rarityScriptableObject.rarityColours[0].imageColor;
                    uIShopItems[i].name.color = rarityScriptableObject.rarityColours[0].textColor;
                    uIShopItems[i].subName.color = rarityScriptableObject.rarityColours[0].subTextColor;
                    break;
                case 1:
                    uIShopItems[i].backGround.color = rarityScriptableObject.rarityColours[1].imageColor;
                    uIShopItems[i].name.color = rarityScriptableObject.rarityColours[1].textColor;
                    uIShopItems[i].subName.color = rarityScriptableObject.rarityColours[1].subTextColor;
                    break;
                case 2:
                    uIShopItems[i].backGround.color = rarityScriptableObject.rarityColours[2].imageColor;
                    uIShopItems[i].name.color = rarityScriptableObject.rarityColours[2].textColor;
                    uIShopItems[i].subName.color = rarityScriptableObject.rarityColours[2].subTextColor;
                    break;
                case 3:
                    uIShopItems[i].backGround.color = rarityScriptableObject.rarityColours[3].imageColor;
                    uIShopItems[i].name.color = rarityScriptableObject.rarityColours[3].textColor;
                    uIShopItems[i].subName.color = rarityScriptableObject.rarityColours[3].subTextColor;
                    break;
            }
            i++;
        }
        yield return 0;
    }
    private void UpdateCoinAmount()
    {
        currentCoinAmountText.text = GlobalController.Instance.coin.ToString();
    }
    public void Buy(int ItemIndex)
    {
        shopSystem.AddItem(ItemIndex);
        GlobalController.Instance.coin -= float.Parse(uIShopItems[ItemIndex].moneyAmount.text);
        UpdateCoinAmount();
    }
}