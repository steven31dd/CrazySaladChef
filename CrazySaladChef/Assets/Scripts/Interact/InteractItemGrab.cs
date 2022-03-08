using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractItemGrab : BaseInteraction
{
    [SerializeField] private Item item;
    [SerializeField] private GameObject popupGO;
    // Start is called before the first frame update
    public override void OnInteract(GameObject player)
    {
        PlayerInventory plyInv = player.GetComponent<PlayerInventory>();

        if (plyInv.AddItem(item.image, item.id))
        {
            GameObject newPopGO = Instantiate(popupGO);
            newPopGO.GetComponent<PopUp>().InitPopUp(item, player.transform);
        }
    }
}
