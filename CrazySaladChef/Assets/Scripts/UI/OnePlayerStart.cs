using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerStart : MonoBehaviour
{
   public void OnePlayerClick()
    {
        GameManager.Instance.StartGame(1);
    }
}
