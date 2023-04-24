using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.text = "";
        stats.text += "+" + (GlobalController.Instance.bonusDamage) + "% Damage<br>";
        stats.text += "+" + (GlobalController.Instance.bonusAttackSpeed) + "% AttackSpeed<br>";
        stats.text += "+" + (1.5f+GlobalController.Instance.bonusRange/10) + " Range<br>";
        stats.text += "+" + (GlobalController.Instance.bonusHealthAmount + GameObject.FindObjectOfType<PlayerHealthSystem>().Health) + " health<br>";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
