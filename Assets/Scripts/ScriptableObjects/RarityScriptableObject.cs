using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RarityColourScriptableObject")]
public class RarityScriptableObject : ScriptableObject
{
    public List<RarityColour> rarityColours = new List<RarityColour>();
}
