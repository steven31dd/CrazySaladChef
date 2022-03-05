using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGrabMeal : BaseInteraction
{
    Meal meal = new Meal();
    public override void OnInteract(GameObject player)
    {
        
    }

    public void AddToMealCombo(ItemID id)
    {
        meal.AddItemToMeal(id);
        meal.CheckMeal();
    }

}
