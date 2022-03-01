using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [Header("Keys")]
    [SerializeField] private KeyCode _forward = KeyCode.W;
    [SerializeField] private KeyCode _backward = KeyCode.S;
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _interaction = KeyCode.F;

    Vector2 _movement;

    private void Awake()
    {
    }

    public bool Interact()
    {
        if (Input.GetKeyDown(_interaction)){
            return true;
        }

        return false;
    }

    public Vector2 Move()
    {
        _movement = Vector2.zero;

        if (Input.GetKey(_forward))
        {
            _movement.y = 1;
        }

        if (Input.GetKey(_backward))
        {
            _movement.y = -1;
        }

        if (Input.GetKey(_left))
        {
            _movement.x = -1;
        }

        if (Input.GetKey(_right))
        {
            _movement.x = 1;
        }

        return _movement;
    }

}
