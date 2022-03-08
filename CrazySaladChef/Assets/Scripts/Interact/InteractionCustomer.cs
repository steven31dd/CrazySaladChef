using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCustomer : BaseInteraction
{
    // Start is called before the first frame update
    [SerializeField] GameObject Customer;
    [SerializeField] Transform customerSpot;
    [SerializeField] GameObject mealRequired;

    public int GetCustomerSpotCount { get { return customerSpot.childCount; } }

    public void SetNewCustomer(GameObject newCustomer)
    {
            Customer = newCustomer;
            Customer.transform.position = customerSpot.position;
            Customer.transform.parent = customerSpot;
            Customer.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void RemoveCustomer()
    {
        Destroy(Customer);
    }

    public override void OnInteract(GameObject player)
    {
        if (Customer == null) return;

        NPCOrder order = Customer.GetComponent<NPCOrder>();

        if (order.GaveOrder())
        {
            //XD forgot to add this to stop customer from leaving empty handed
            if (player.GetComponent<PlayerInventory>().PlayerMeal.ID == comboID.NONE ||
                player.GetComponent<PlayerInventory>().PlayerMeal.ID == comboID.UNKNOWN ||
                player.GetComponent<PlayerInventory>().PlayerMeal.ID == comboID.INCOMPLETE) return;

            if(order.ReceiveOrder(player, player.GetComponent<PlayerInventory>().PlayerMeal))
            {
                //set to null
                mealRequired.GetComponent<RequiredOrder>().SetRequiredOrder(comboID.NONE);
                Destroy(Customer);
            }
        }
        else
        {
            mealRequired.GetComponent<RequiredOrder>().SetRequiredOrder(order.GiveOrder());
        }

    }

    protected override void Update()
    {
        if(customerSpot.childCount == 0 || Customer == null)
        {
            mealRequired.GetComponent<RequiredOrder>().SetRequiredOrder(comboID.NONE);
        }
        else
        {
            if(Customer != null)
            {
                if (Customer.GetComponent<NPCOrder>().WaitedLong)
                {
                    Destroy(Customer);
                }
            }
        }
    }
}
