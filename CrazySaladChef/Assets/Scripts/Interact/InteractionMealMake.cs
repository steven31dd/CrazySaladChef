using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMealMake : BaseInteraction
{
    [SerializeField] GameObject MealSpot;
    [SerializeField] GameObject ProgressionBar;
    [SerializeField] float processTime = 2f;
    bool isDone = true;
    GameObject plyGO;

    public override void OnInteract(GameObject player)
    {
        //return if already being used
        if (!isDone) return;

        //Save plyGO for oninteractended
        plyGO = player;

        //return if no item
        if (plyGO.GetComponent<PlayerInventory>().GetFirstSlotID() == ItemID.NONE) return;

        //Stop Player
        plyGO.GetComponent<PlayerMovement>().IsWorking = true;

        //Set ProgressBar position and show
        ProgressionBar.transform.position = new Vector3(plyGO.transform.position.x, plyGO.transform.position.y + 0.3f, plyGO.transform.position.z);
        ProgressionBar.SetActive(true);

        //StartTimer
        ProgressionBar.GetComponent<Progress>().StartTimer(processTime, plyGO.transform);

        isDone = false;
        

    }



    protected override void Update()
    {
        if (isDone) return;

        if(ProgressionBar.GetComponent<Progress>().IsProgressComplete())
        {
            OnInteractEnded();
            ProgressionBar.SetActive(false);
            isDone = true;
        }
    }


    private void OnInteractEnded()
    {
        InteractionGrabMeal IGB = MealSpot.GetComponent<InteractionGrabMeal>();
        PlayerInventory plyInv = plyGO.GetComponent<PlayerInventory>();
        
        //add itemid to meal
        IGB.AddToMealCombo(plyInv.GetFirstSlotID());

        //remove item from player inventory
        plyInv.RemoveFirstItem();

        //player can now move
        plyGO.GetComponent<PlayerMovement>().IsWorking = false;


    }
}
