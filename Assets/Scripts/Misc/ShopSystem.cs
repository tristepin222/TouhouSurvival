using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSystem
{
    private ItemScriptableObject[] itemScriptableObjects;
    private ItemScriptableObject[] selectedPool =  new ItemScriptableObject[4];
    // Start is called before the first frame update
    private void GetItems()
    {
        itemScriptableObjects = Resources.LoadAll<ItemScriptableObject>("ItemScriptableObjects/Items/");
    }
    public ItemScriptableObject[] CheckWeight(bool[] lockedItems,float penality = 0)
    {
        if(itemScriptableObjects == null)
        {
            GetItems();
        }
        int i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = Random.Range(0, weightTotal - penality);
        foreach (ItemScriptableObject itemScriptableObject in itemScriptableObjects)
        {

            if (random <= itemScriptableObject.weight)
            {
                if (i < selectedPool.Length)
                {
                    if (selectedPool[i] == null || !lockedItems[i])
                    {
                        selectedPool[i] = itemScriptableObject;
                    }
                }
                i++;

            }
            else
            {
                random -= itemScriptableObject.weight;
            }
        }
        CheckEmpty();
        return selectedPool;
    }
    private void CheckEmpty()
    {
        bool[] locks = new bool[4];
        for (int i = 0; i < selectedPool.Length; i++)
        {
            if (selectedPool[i] == null)
            {
                locks[i] = true;
                CheckWeight(locks);
            }
        }
    }
    private float CalculateWeightTotal()
    {
        float weightTotal = 0f;
        foreach (ItemScriptableObject itemScriptableObject in itemScriptableObjects)
        {
            weightTotal += itemScriptableObject.weight;
        }
        return weightTotal;
    }

    public void MoveItem(int fromIndex, int toIndex)
    {
        selectedPool[toIndex] = selectedPool[fromIndex];
    }
    public void RemoveItem(int itemIndex)
    {
        selectedPool[itemIndex] = null;
    }

    public void AddItem(int itemIndex)
    {
        switch (selectedPool[itemIndex].itemCategory)
        {
            case Item.ItemType.PassiveItem:
                foreach(ItemInfo itemInfo in selectedPool[itemIndex].itemInfos)
                {
                    switch (itemInfo.name)
                    {
                        case "Speed":
                            GlobalController.Instance.bonusSpeed += itemInfo.value;
                            break;
                        case "Attack Speed":
                            GlobalController.Instance.bonusAttackSpeed += itemInfo.value;
                            break;
                        case "Range":
                            GlobalController.Instance.bonusRange += itemInfo.value;
                            break;
                        case "Damage":
                            GlobalController.Instance.bonusDamage += itemInfo.value;
                            break;
                    }
                }
                RemoveItem(itemIndex);
                break;
        }
    }
}
