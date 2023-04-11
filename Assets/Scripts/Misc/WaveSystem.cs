using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class WaveSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveValueText;
    [SerializeField] TextMeshProUGUI timeValueText;
    [SerializeField] float baseTimeValue;
    [SerializeField] float baseWaveValue;
    [SerializeField] string sceneName;
    private float timeValue;
    private float waveValue;
    private bool collecting;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = baseTimeValue;
        waveValue = baseWaveValue;
        InvokeRepeating("setTime", 0, 1.0f);
    }

    private void setTime()
    {
        timeValue--;
        if (timeValue < 0)
        {
            if (!collecting)
            {
                StartCoroutine(CollectAllXp());
            }
        }
        else
        {
            timeValueText.text = timeValue.ToString();
        }
    }

    private IEnumerator CollectAllXp()
    {
        collecting = true;
        Loot[] loots = FindObjectsOfType<Loot>();
        foreach (Loot loot in loots)
        {
            loot.MoveTowards();
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(Teleport());

    }
    private IEnumerator Teleport()
    {
        SceneManager.LoadScene(sceneName);
        yield return 0;
    }
}
