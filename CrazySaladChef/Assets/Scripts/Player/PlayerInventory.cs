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
        items[0] = null;
        items[1] = null;
        ResetPlayerMeal();
    }

    public bool AddItem(Item item)
    {
        //simply return if inventory is filled
        if (items[0] != null && items[1] != null)
        {
            Debug.LogWarning("Additem both slots filled");
            return false;
        }

        //trying adding in first slot, if not then second
        if(items[0] == null)
        {
            items[0] = item;
            invUI.SetImage(1, item.image);
        }
        else
        {
            items[1] = item;
            invUI.SetImage(2, item.image);
        }

        return true;
    }

    //returns -1 if null
    public ItemID GetFirstSlotID()
    {
        if(items[0] != null)
        {
            return items[0].id;
        }

        //if we reached here item [0] was null
        return ItemID.NONE;
    }

    public void RemoveFirstItem()
    {

        if(items[0] != null)
        {
            items[0] = null;
            invUI.ClearSlot(1);

            //if item[1] not null, pull forward in array
            if (items[1] != null)
            {
                items[0] = items[1];
                items[1] = null;

                invUI.SetImage(1, items[0].image);
                invUI.ClearSlot(2);

            }
        }

       
    }
    

}
