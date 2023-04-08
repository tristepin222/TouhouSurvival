using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UpgradeScriptableObject")]
public class UpgradeScriptableObject : ScriptableObject
{
    public string UpgradeName;
    public float UpgradeValue;
    public string UpgradeDescription;
}
