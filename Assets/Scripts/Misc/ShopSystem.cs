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
    public void GetItems()
    {
        itemScriptableObjects = Resources.LoadAll<ItemScriptableObject>("ItemScriptableObjects/Items/");
    }
    public ItemScriptableObject[] CheckWeight(float penality = 0)
    {
        int i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = Random.Range(0, weightTotal - penality);
        foreach (ItemScriptableObject itemScriptableObject in itemScriptableObjects)
        {

            if (random <= itemScriptableObject.weight)
            {
                if (i < selectedPool.Length)
                {
                    if (selectedPool[i] == null)
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
        for (int i = 0; i < selectedPool.Length; i++)
        {
            if (selectedPool[i] == null)
            {
                CheckWeight();
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
}
