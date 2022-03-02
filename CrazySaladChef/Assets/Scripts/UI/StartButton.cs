using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject subMenu;
    [SerializeField] GameObject Menu;
    
    public void StartClick()
    {
        //Check if sub-menu and menu are defined if not log it and return
        if(subMenu == null)
        {
            Debug.LogWarning("No sub-menu defined");
            return;
        }

        if (Menu == null)
        {
            Debug.LogWarning("No Menu defined");
            return;
        }

        //Show the sub-menu and set the menu inactive
        Menu.SetActive(false);
        subMenu.SetActive(true);
    }
}
