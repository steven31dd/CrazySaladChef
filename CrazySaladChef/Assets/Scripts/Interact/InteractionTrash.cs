using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrash : BaseInteraction
{
    public override void OnInteract(GameObject player)
    {
        if (player.GetComponent<PlayerInventory>().PlayerMeal.ID == comboID.NONE)
            return;

        player.GetComponent<PlayerInventory>().ResetPlayerMeal();
    }

}
