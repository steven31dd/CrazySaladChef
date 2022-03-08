using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//holds items and the meal
public class PlayerInventory : MonoBehaviour
{
    //Serialized so I can test, using Array instead of list
    [SerializeField] private Item[] items = new Item[2];
    [SerializeField] InventoryUI invUI;
    [SerializeField] MealItem playerMeal;

    public MealItem PlayerMeal { get { return playerMeal; } set { playerMeal = value; } }

    public void ResetPlayerMeal()
    {
        playerMeal.ID = comboID.NONE;
        playerMeal.mealSprite = null;
    }

    public void Awake()
    {
        invUI = GetComponent<InventoryUI>();
        items[0] = new Item();
        items[1] = new Item();
        ResetPlayerMeal();
    }

    public bool AddItem(Sprite sprite, ItemID id)
    {
        //simply return if inventory is filled
        if (items[0].id != ItemID.NONE && items[1].id != ItemID.NONE)
        {
            Debug.LogWarning("Additem both slots filled");
            return false;
        }

        //trying adding in first slot, if not then second
        if(items[0].id == ItemID.NONE)
        {
            items[0].image = sprite;
            items[0].id = id;
            invUI.SetImage(1, items[0].image);
        }
        else
        {
            items[1].image = sprite;
            items[1].id = id;
            invUI.SetImage(2, items[1].image);
        }

        return true;
    }

    //returns -1 if null
    public ItemID GetFirstSlotID()
    {
        if(items[0].id != ItemID.NONE)
        {
            return items[0].id;
        }

        //if we reached here item [0] was null
        return ItemID.NONE;
    }

    public void RemoveFirstItem()
    {

        if(items[0].id != ItemID.NONE)
        {
            items[0].Reset();
            invUI.ClearSlot(1);

            //if item[1] not null, pull forward in array
            if (items[1].id != ItemID.NONE)
            {
                items[0].image = items[1].image;
                items[0].id = items[1].id;
                items[1].Reset();

                invUI.SetImage(1, items[0].image);
                invUI.ClearSlot(2);

            }
        }

       
    }
    

}
