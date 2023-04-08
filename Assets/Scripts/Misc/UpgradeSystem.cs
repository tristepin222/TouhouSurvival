using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] GameObject[] images;
    [SerializeField] UpgradeScriptableObject[] upgradeScriptableObjects;

    private UpgradeScriptableObject[] selectedPool = new UpgradeScriptableObject[4] ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckWeight());
    }
    private IEnumerator CheckWeight()
    {
        int i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = Random.Range(0, weightTotal);
        foreach (UpgradeScriptableObject upgradeScriptableObject in upgradeScriptableObjects)
        {

            if (random <= upgradeScriptableObject.weight)
            {
                if(i <= images.Length)
                {
                    selectedPool[i] = upgradeScriptableObject;
                }
                i++;
            }
            else
            {
                random -= upgradeScriptableObject.weight;
            }
        }
        StartCoroutine(showUpgrades());
        yield return 0;
    }

    private float CalculateWeightTotal()
    {
        float weightTotal = 0f;
        foreach (UpgradeScriptableObject upgradeScriptableObject in upgradeScriptableObjects)
        {
            weightTotal += upgradeScriptableObject.weight;
        }
        return weightTotal;
    }
    private IEnumerator showUpgrades()
    {
        int i = 0;
        foreach(UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = upgradeScriptableObject.upgradeName;
            images[i].transform.Find("Image").GetComponent<Image>().sprite = upgradeScriptableObject.upgradeSprite;
            images[i].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = upgradeScriptableObject.upgradeDescription;
            i++;
        }
        yield return 0;
    }
}
