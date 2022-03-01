using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Order
{
    public int OrderID;
    public GameObject OrderEntity;
    public string OrderName;
}

public enum NPCState
{
    InRoute, WaitToOrder, WaitForOrder, OrderCompleted, OrderFailed
}

public enum NPCFeel
{
    NEUTRAL, UNHAPPY, HAPPY, LEAVING
}

public class NPCOrder : MonoBehaviour
{
    [SerializeField] Order _npcOrder;
    private GameObject _playerGivenOrder = null;

    private bool hasGivenOrder = false;
    private bool hasWaitedLong = false;
    private bool inPositionForOrder = false;

    [SerializeField][Range(1, 500)] private int _potentialScore = 100;

    [SerializeField] private Vector2 _randomOrderTime;
    private float _orderTime = 0.0f;
    [SerializeField] private Vector2 _randomWaitTime;
    private float _waitTime = 0.0f;

    private void Start()
    {
        _orderTime = Random.Range(_randomOrderTime.x, _randomOrderTime.y);
        _waitTime = Random.Range(_randomWaitTime.x, _randomWaitTime.y);
    }

    public Order GiveOrder()
    {
        return _npcOrder;
    }

}
