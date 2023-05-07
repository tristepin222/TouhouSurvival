using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;
    public float bonusHealthAmount;
    public float bonusDamage;
    public float bonusAttackSpeed;
    public float bonusRange;
    public int level;
    public int levelToUpgrade;
    public float xp;
    public float coin;
    public bool isDead;
    // Start is called before the first frame update
    private void Awake()
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

  