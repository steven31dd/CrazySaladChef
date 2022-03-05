using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Meal", menuName ="Meal Combination")]
public class MealObject : ScriptableObject
{
    // private, do not set, just get
    [SerializeField]private List<ItemID> ids = new List<ItemID>();

    //Reference to meal combination, can be used for a recipe book
    public List<ItemID> GetIDS { get { return ids; } }

    public ItemID GetIDByIndex(int index)
    {
        //safeguard list from out of bounds
        if (index < 0) return ItemID.NONE;
        if (index > ids.Count) return ItemID.NONE;

        return ids[index];
    }
}
