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
        timeValueText.text = timeValue.ToString();
        if(timeValue == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
