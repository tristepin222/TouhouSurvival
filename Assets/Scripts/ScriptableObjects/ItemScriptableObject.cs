using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemType;
    public List<float> itemValues = new List<float>();
    public List<ItemInfo> itemInfos = new List<ItemInfo>();
    public List<Sprite> itemSprite = new List<Sprite>();
    public List<Color> itemColours = new List<Color>();
    public int weight;
    public int rarity;
    public float scaleX;
    public float scaleY;
}
