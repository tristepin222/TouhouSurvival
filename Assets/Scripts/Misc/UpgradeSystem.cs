using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] GameObject[] images;
    [SerializeField] UpgradeScriptableObject[] upgradeScriptableObjects;

    private UpgradeScriptableObject[] selectedPool = new UpgradeScriptableObject[5] ;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalController.Instance.levelToUpgrade > 0)
        {
            GlobalController.Instance.levelToUpgrade--;
            StartCoroutine(CheckWeight());
        }
    }
    private IEnumerator CheckWeight(float penality = 0)
    {
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].gameObject.SetActive(true);
            i++;
        }
        i = 0;
        float weightTotal = CalculateWeightTotal();
        float random = Random.Range(0, weightTotal-penality);
        foreach (UpgradeScriptableObject upgradeScriptableObject in upgradeScriptableObjects)
        {

            if (random <= upgradeScriptableObject.weight)
            {
                if(i <= selectedPool.Length)
                {
                    if (selectedPool[i] == null)
                    {
                        selectedPool[i] = upgradeScriptableObject;
                    }
                }
                i++;
            }
            else
            {
                random -= upgradeScriptableObject.weight;
            }
        }

        StartCoroutine(CheckEmpty());
        yield return 0;
    }
    private IEnumerator CheckEmpty()
    {
        for(int i = 0; i < selectedPool.Length; i++)
        {
            if(selectedPool[i] == null)
            {
                StartCoroutine(CheckWeight(500));
                yield break;
            }
        }
        StartCoroutine(ShowUpgrades());
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
    private IEnumerator ShowUpgrades()
    {
        int i = 0;
        foreach(UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = upgradeScriptableObject.upgradeName;
            images[i].transform.Find("Image").GetComponent<Image>().sprite = upgradeScriptableObject.upgradeSprite;
            images[i].transform.Find("Image").GetComponent<Image>().color = upgradeScriptableObject.upgradeColor;
            images[i].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = upgradeScriptableObject.upgradeDescription;
            i++;
        }
        yield return 0;
    }

    public void Buy(int upgradeIndex)
    {
        switch(selectedPool[upgradeIndex].upgradeName)
        {
            default:
                break;
            case "Health":
                GlobalController.Instance.bonusHealthAmount += selectedPool[upgradeIndex].upgradeValue;
                break;
        }
        int i = 0;
        foreach (UpgradeScriptableObject upgradeScriptableObject in selectedPool)
        {
            images[i].gameObject.SetActive(false);
            i++;
        }
        if (GlobalController.Instance.levelToUpgrade > 0)
        {
            GlobalController.Instance.levelToUpgrade--;
            StartCoroutine(CheckWeight());
        }
    }
}
