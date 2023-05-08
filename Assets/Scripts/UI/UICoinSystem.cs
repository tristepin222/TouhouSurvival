using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoinSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uIMoneyAmount;

    public void SetCoin(float amount)
    {
        uIMoneyAmount.text = amount.ToString();
    }
}
