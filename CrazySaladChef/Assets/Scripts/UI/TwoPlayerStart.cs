using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerStart : MonoBehaviour
{
    public void TwoPlayerClick()
    {
        GameManager.Instance.StartGame(2);
    }
}
