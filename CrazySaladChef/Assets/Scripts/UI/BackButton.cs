using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//same as startbutton but activates in reverse
public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject subMenu;
    [SerializeField] GameObject Menu;

    public void StartClick()
    {
        //Check if sub-menu and menu are defined if not log it and return
        if (subMenu == null)
        {
            Debug.LogWarning("No sub-menu defined");
            return;
        }

        if (Menu == null)
        {
            Debug.LogWarning("No Menu defined");
            return;
        }

        //Show the menu and set the sub-menu inactive
        subMenu.SetActive(false);
        Menu.SetActive(true);
        
    }
}
