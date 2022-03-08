using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 
/// This is a simple game featuring simple interactions.
/// I do not feel it is necessary to build a full fledged inventory system
/// ex: abstract item classes or scriptables objects.
/// I will be using a simple class here with a enum as id
/// </summary> 

public enum ItemID
{
    NONE, CABBAGE, CARROT, BEET, EGG, CHICKEN, ONION
}

[System.Serializable]
public class Item
{
    public Sprite image;
    public ItemID id;

    public Item()
    {
        image = null;
        id = ItemID.NONE;
    }

    public void Reset()
    {
        image = null;
        id = ItemID.NONE;
    }
}
