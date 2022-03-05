using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Same as Item, just a simple class with enum id
public enum comboID
{
    NONE,
    CABBAGE_CARROT_BEET,
    CARROT_CHICKEN_ONION,
    BEET_CHICKEN,
    CABBAGE_EGG_ONION,
    BEET_CABBAGE_ONION,
    INCOMPLETE,
    UNKNOWN
}

public class Meal
{
    List<ItemID> _meal = new List<ItemID>();
    private comboID _mealCombo = comboID.NONE;

    public Meal()
    {
        ClearMeal();
    }

    public comboID GetMealCombo { get { return _mealCombo; } }

    public void AddItemToMeal(ItemID item)
    {
        _meal.Add(item);
    }

    public void ClearMeal()
    {
        _meal.Clear();
        _mealCombo = comboID.NONE;
    }

    //lengthy but I think a switch case would be more readible but it feels costly
    public void CheckMeal()
    {
        //No Items in list
        if(_meal.Count == 0)
        {
            _mealCombo = comboID.NONE;
            return;
        }

        //more items then any combinations found
        if(_meal.Count > 3)
        {
            _mealCombo = comboID.UNKNOWN;
            return;
        }

        //if one item in list
        if(_meal.Count == 1)
        {
            //simply say its incomplete
            _mealCombo = comboID.INCOMPLETE;
        }

        //if 2 items in list
        if(_meal.Count == 2)
        {
            //if beet
            if (_meal[0] == ItemID.BEET)
            {
                //with chicken
                if(_meal[1] == ItemID.CHICKEN)
                {
                    //found combo
                    _mealCombo = comboID.BEET_CHICKEN;
                    return;
                }

                //with cabbage
                if (_meal[1] == ItemID.CABBAGE)
                {
                    _mealCombo = comboID.INCOMPLETE;
                    return;
                }
            }

            //Cabbage as first item
            if (_meal[0] == ItemID.CABBAGE)
            {
                //with carrot
                if(_meal[1] == ItemID.CARROT)
                {
                    _mealCombo = comboID.INCOMPLETE;
                    return;
                }

                //with egg
                if(_meal[1] == ItemID.EGG)
                {
                    _mealCombo = comboID.INCOMPLETE;
                    return;
                }

            }

            //Carrot as first item
            if (_meal[0] == ItemID.CARROT)
            {

                //with chicken
                if(_meal[1] == ItemID.CHICKEN)
                {
                    _mealCombo = comboID.INCOMPLETE;
                    return;
                }
            }
        }

        //if 3 items in list
        if(_meal.Count == 3)
        {
            //Cabbage as first item
            if(_meal[0] == ItemID.CABBAGE)
            {
                //with carrot and beet
                if (_meal[1] == ItemID.CARROT)
                {
                    if (_meal[2] == ItemID.BEET)
                    {
                        _mealCombo = comboID.CABBAGE_CARROT_BEET;
                        return;
                    }
                }

                //with egg and onion
                if (_meal[1] == ItemID.EGG)
                {
                    if (_meal[2] == ItemID.ONION)

                    {
                        _mealCombo = comboID.CABBAGE_EGG_ONION;
                        return;
                    }
                }
            }

            //Beet as first item
            if (_meal[0] == ItemID.BEET)
            {
                //with cabbage
                if (_meal[1] == ItemID.CABBAGE)
                {
                    if(_meal[2] == ItemID.ONION)
                    {
                        _mealCombo = comboID.BEET_CABBAGE_ONION;
                        return;
                    }
                }
            }

            //Carrot as first item
            if (_meal[0] == ItemID.CARROT)
            {
                //with cabbage
                if (_meal[1] == ItemID.CHICKEN)
                {
                    if (_meal[2] == ItemID.ONION)
                    {
                        _mealCombo = comboID.CARROT_CHICKEN_ONION;
                        return;
                    }
                }
            }

            //if none found then set as unknown
            _mealCombo = comboID.UNKNOWN;
        }
            
    }
}
