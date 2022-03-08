using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredOrder : MonoBehaviour
{
    [SerializeField] List<Sprite> MealSprites = new List<Sprite>();
    [SerializeField] SpriteRenderer spriteRend;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void SetRequiredOrder(comboID meal)
    {
        if (meal == comboID.NONE)
        {
            spriteRend.sprite = null;
            return;
        }

        spriteRend.sprite = comboSprite(meal);
    }

    private Sprite comboSprite(comboID meal)
    {
        //Set Sprite Depending on comboid
        switch (meal)
        {
            case comboID.CABBAGE_CARROT_BEET:
                return MealSprites[4];
            case comboID.CARROT_CHICKEN_ONION:
                return MealSprites[3];
            case comboID.BEET_CABBAGE_ONION:
                return MealSprites[2];
            case comboID.BEET_CHICKEN:
                return MealSprites[1];
            case comboID.CABBAGE_EGG_ONION:
                return MealSprites[0];
            default: return null;
        }
    }
}
