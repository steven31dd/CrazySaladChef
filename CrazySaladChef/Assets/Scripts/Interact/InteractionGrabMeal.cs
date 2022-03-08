using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGrabMeal : BaseInteraction
{
    [SerializeField] GameObject POPUP;
    Meal meal = new Meal();
    [SerializeField]List<Sprite> MealSprites = new List<Sprite>();
    public override void OnInteract(GameObject player)
    {
        if (meal.GetMealCombo == comboID.NONE) return;

        //gather info on meal created
        comboID newPlayerMeal = meal.GetMealCombo;
        Debug.Log(newPlayerMeal);
        Sprite newMealSprite = comboSprite(newPlayerMeal);

        //Create New MealItem with info
        MealItem newMeal;
        newMeal.ID = newPlayerMeal;
        newMeal.mealSprite = newMealSprite;

        //Give it to Player INV
        player.GetComponent<PlayerInventory>().PlayerMeal = newMeal;

        //Pop Up meal received
        Instantiate(POPUP);
        POPUP.GetComponent<PopUp>().InitPopUp(comboSprite(newPlayerMeal), player.transform);

        //Clear this meal out
        meal.ClearMeal();
    }

    private Sprite comboSprite(comboID meal)
    {
        //Set Sprite Depending on comboid
        switch (meal)
        {
            case comboID.CABBAGE_CARROT_BEET:
                return MealSprites[0];
            case comboID.CARROT_CHICKEN_ONION:
                return MealSprites[4];
            case comboID.BEET_CABBAGE_ONION:
                return MealSprites[1];
            case comboID.BEET_CHICKEN:
                return MealSprites[3];
            case comboID.CABBAGE_EGG_ONION:
                return MealSprites[2];
            case comboID.UNKNOWN:
                return MealSprites[5];
            case comboID.INCOMPLETE:
                return MealSprites[5];
            default: return null;
        }
    }

    public void AddToMealCombo(ItemID id)
    {
        meal.AddItemToMeal(id);
        meal.CheckMeal();
  
    }

}
