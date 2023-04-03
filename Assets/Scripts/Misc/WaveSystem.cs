using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveValueText;
    [SerializeField] TextMeshProUGUI timeValueText;
    [SerializeField] float baseTimeValue;
    [SerializeField] float baseWaveValue;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setTime", 0, 1.0f);
    }

    private void setTime()
    {
        baseTimeValue--;
        timeValueText.text = baseTimeValue.ToString();
    }
}
