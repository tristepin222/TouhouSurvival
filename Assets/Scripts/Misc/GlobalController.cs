using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;
    public float bonusHealthAmount;
    public float bonusDamage;
    public float bonusAttackSpeed;
    public float bonusSpeed;
    public float bonusRange;
    public int level;
    public int levelToUpgrade;
    public float xp;
    public float coin;
    public bool isDead;
    public ItemScriptableObject[] weapons;
    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    public float soundValue;
    public float musicValue;
    // Start is called before the first frame update
    private void Start()
    {
        bonusDamage += 1;
        bonusAttackSpeed += 1;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

  