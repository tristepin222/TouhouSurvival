using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class UIShopSystem : MonoBehaviour
{
    [SerializeField] UIShopElement[] uIShopItems;
    [SerializeField] UIShortUIElement template;
    [SerializeField] GameObject uIWeaponParent;
    [SerializeField] RarityScriptableObject rarityScriptableObject;
    [SerializeField] TextMeshProUGUI currentCoinAmountText;
    [SerializeField] TextMeshProUGUI rerollCoinAmountText;
    [SerializeField] GameObject parent;
    [SerializeField] Volume volume;
    [SerializeField] FightSystem fightSystem;
    [SerializeField] UIItemsShower iUItemsShower;
    float weaponPosX;
    float weaponPosY;

    private List<GameObject> uIWeapons= new List<GameObject>();
    private bool[] locks;
    private ItemScriptableObject[] pool;
    private int rerollAmount = 1;
    ShopSystem shopSystem;
    // Start is called before the first frame update
    private void Start()
    {
        weaponPosX = template.parent.gameObject.transform.position.x;
        weaponPosY = template.parent.gameObject.transform.position.y;
        locks = new bool[4];
        shopSystem = new ShopSystem();
        ShowWeapons();
        Reroll();
    }
    private IEnumerator ShowUpgrades(ItemScriptableObject[] selectedPool)
    {
        int i = 0;
        foreach (ItemScriptableObject itemScriptableObject in selectedPool)
        {
            uIShopItems[i].parent.gameObject.SetActive(true);
            uIShopItems[i].imageSprite.sprite = itemScriptableObject.itemShopSprite[0];
            uIShopItems[i].name.text = itemScriptableObject.itemName;
            uIShopItems[i].imageSprite.rectTransform.localScale = new Vector2(itemScriptableObject.scaleX, itemScriptableObject.scaleY);
            uIShopItems[i].subName.text = itemScriptableObject.itemType;
            uIShopItems[i].moneyAmount.text = itemScriptableObject.cost.ToString();
            uIShopItems[i].stats.text = "";
            foreach (ItemInfo itemInfo in itemScriptableObject.itemInfos)
            {
                uIShopItems[i].stats.text += "+" + "<color=" + "#4A58FF" + ">" + itemInfo.value + "</color>" + " " + itemInfo.name + "<br>";
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

    private void HideUpgrade(int indexItem)
    {
        uIShopItems[indexItem].parent.gameObject.SetActive(false);
    }

    private void UpdateCoinAmount()
    {
        currentCoinAmountText.text = GlobalController.Instance.coin.ToString();
    }
    public void Buy(int indexItem)
    {
        float price = float.Parse(uIShopItems[indexItem].moneyAmount.text);
        if ((GlobalController.Instance.coin - price) > 0)
        {
            if (shopSystem.TryAddItem(indexItem))
            {
                GlobalController.Instance.coin -= float.Parse(uIShopItems[indexItem].moneyAmount.text);
                UpdateCoinAmount();
                HideUpgrade(indexItem);
                fightSystem.SetWeapons();
                ShowWeapons();
                iUItemsShower.showItems();
            }
        }
    }
    public void Reroll(bool updateReroll = false)
    {
        float rerollPrice = 15 * rerollAmount;
        if ((GlobalController.Instance.coin - rerollPrice) > 0)
        {
            if (updateReroll) 
            {
                rerollAmount++;
                GlobalController.Instance.coin -= rerollPrice;
            }
            pool = shopSystem.CheckWeight(locks);
            StartCoroutine(ShowUpgrades(pool));
            UpdateCoinAmount();
            rerollPrice = 15 * rerollAmount;
            rerollCoinAmountText.text = rerollPrice.ToString();
        }
    }
    public void LockItem(int lockIndex)
    {
        if (locks[lockIndex])
        {
            locks[lockIndex] = false;
        }
        else
        {
            locks[lockIndex] = true;
        }
    }
    public void Confirm()
    {
        volume.enabled = false;
        parent.SetActive(false);
    }

    public void ShowWeapons()
    {
        int index = 0;
        weaponPosX = template.parent.gameObject.transform.position.x;
        weaponPosY = template.parent.gameObject.transform.position.y;
        foreach (GameObject uIWeapon in uIWeapons)
        {
            Destroy(uIWeapon);
        }
        uIWeapons = new List<GameObject>();
        foreach (ItemScriptableObject weapon in GlobalController.Instance.weapons)
        {
            if (weapon != null)
            {
                uIWeapons.Add(Instantiate(template.parent.gameObject, uIWeaponParent.transform));
                uIWeapons[index].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = weapon.itemName[0] + "" + weapon.itemName[weapon.itemName.Length - 1];
                uIWeapons[index].SetActive(true);
                RectTransform rectTransform = uIWeapons[index].GetComponent<RectTransform>();
                uIWeapons[index].transform.position = new Vector3(weaponPosX, weaponPosY, 0);
                weaponPosX += rectTransform.rect.width + 5;
                if (index == 2)
                {
                    weaponPosX = template.parent.gameObject.transform.position.x;
                    weaponPosY = template.parent.gameObject.transform.position.y;
                    weaponPosY -= rectTransform.rect.height + 5;
                }
                index++;
            }
        }
    }

    public void OnEnable()
    {
        volume.enabled = true;
    }
}