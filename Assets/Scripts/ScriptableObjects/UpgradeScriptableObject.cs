using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UpgradeScriptableObject")]
public class UpgradeScriptableObject : ScriptableObject
{
    public string upgradeName;
    public float upgradeValue;
    public string upgradeDescription;
    public Sprite upgradeSprite;
    public Color upgradeColor;
    public int weight;
    public int rarity;
}
