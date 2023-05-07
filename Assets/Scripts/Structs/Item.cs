using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public ItemType itemType;
    public enum ItemType
    {
        Coin,
        XPOrb,
    }
}
