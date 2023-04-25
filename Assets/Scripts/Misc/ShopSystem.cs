using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] GameObject[] shopItems;
    private ItemScriptableObject[] itemScriptableObjects;
    private ItemScriptableObject[] selectedPool =  new ItemScriptableObject[4];
    // Start is called before the first frame update
    void Start()
    {
        itemScriptableObjects = Resources.LoadAll<ItemScriptableObject>("ItemScriptableObjects/Items/");
        StartCoroutine(CheckWeight());

    }
    private IEnumerator CheckWeight(float penality = 0)
    {
        int i = 0;

        i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = UnityEngine.Random.Range(0, weightTotal - penality);
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
        StartCoroutine(CheckEmpty());
        yield return 0;
    }
    private IEnumerator CheckEmpty()
    {
        for (int i = 0; i < selectedPool.Length; i++)
        {
            if (selectedPool[i] == null)
            {
                StartCoroutine(CheckWeight());
                yield break;
            }
        }
        StartCoroutine(ShowUpgrades());
    }
    private IEnumerator ShowUpgrades()
    {
        int i = 0;
        foreach (ItemScriptableObject itemScriptableObject in selectedPool)
        {
            TextMeshProUGUI name = shopItems[i].transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image imageSprite = shopItems[i].transform.Find("ItemSprite").GetComponent<Image>();
            Image image = shopItems[i].GetComponent<Image>();
            imageSprite.sprite = itemScriptableObject.itemSprite[0];
            name.text = itemScriptableObject.itemName;
            imageSprite.rectTransform.localScale = new Vector2(itemScriptableObject.scaleX, itemScriptableObject.scaleY);
            i++;
        }
        yield return 0;
    }
    // Update is called once per frame
    void Update()
    {
        
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
