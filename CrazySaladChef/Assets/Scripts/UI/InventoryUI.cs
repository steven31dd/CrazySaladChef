using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // serialized to test
    [SerializeField] Image SlotOne;
    [SerializeField] Image SlotTwo;
    [SerializeField] GameObject InvPanel;

    public void Awake()
    {
        if (gameObject.CompareTag("PlayerOne"))
        {
            InvPanel = GameObject.FindGameObjectWithTag("P1Inv");

        }
        else if (gameObject.CompareTag("PlayerTwo"))
        {
            InvPanel = GameObject.FindGameObjectWithTag("P2Inv");
        }
      
    }

    public void Start()
    {

        SlotOne = InvPanel.transform.GetChild(0).GetComponent<Image>();
        SlotTwo = InvPanel.transform.GetChild(1).GetComponent<Image>();

        SlotOne.color = Color.clear;
        SlotTwo.color = Color.clear;
    }
    public void SetImage(int slot, Sprite image)
    {
        if (slot <= 0 || slot >= 3) return;
        if (image == null) return;

        if(slot == 1)
        {
            SlotOne.sprite = image;
            SlotOne.color = Color.white;
        }
        else
        {
            SlotTwo.sprite = image;
            SlotTwo.color = Color.white;
        }
       
    }

    public void ClearSlot(int slot)
    {
        if (slot <= 0 || slot >= 3) return;

        if (slot == 1)
        {
            SlotOne = null;
            SlotOne.color = Color.clear;
        }
        else
        {
            SlotTwo = null;
            SlotTwo.color = Color.clear;
        }
    }
}
