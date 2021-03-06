using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform Player1;
    [SerializeField] Transform Player2;
    [SerializeField] Vector3 offset;
    private bool isReady = false;


    public void ReadyCamera()
    {

        //Get Player count and set transform accordingly
        if(GameManager.Instance.NumPlayers == 1)
        {
            Player1 = GameObject.Find("Player1").transform;
        }
        else
        {
            Player1 = GameObject.Find("Player1").transform;
            Player2 = GameObject.Find("Player2").transform;
        }

        //Camera is ready
        isReady = true;
    }
  

  //Create Bounds and encapsulate to get center point
    private void LateUpdate()
    {
        if (!isReady) return;

        Vector3 newPos = GetCenter() + offset;

        transform.position = newPos;
    }

    private Vector3 GetCenter()
    {
        //somehow no players return zero vector3
        if (Player1 == null) return Vector3.zero;
        //if only 1 player return player1 pos
        if (Player2 == null) return Player1.position;

        //if both are detected creat bounds and get center point
        var camBound = new Bounds(Player1.position, Vector3.zero);
        camBound.Encapsulate(Player2.position);

        return camBound.center;
    }
}
