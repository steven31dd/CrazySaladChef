using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _score = 0;

    public int Score { get { return _score; } set { _score = value; } }
}
