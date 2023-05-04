using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemType;
    public List<ItemInfo> itemInfos = new List<ItemInfo>();
    public List<Sprite> itemShopSprite = new List<Sprite>();
    public List<Sprite> itemGameSprite = new List<Sprite>();
    public List<Color> itemColours = new List<Color>();
    public int weight;
    public int rarity;
    public float scaleX;
    public float scaleY;
    public float cost;
}
