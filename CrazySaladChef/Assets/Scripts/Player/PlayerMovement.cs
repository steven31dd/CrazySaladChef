using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput _plyInput;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    private float _speedBonus = 0.0f;

    //Used to Stop player if working
    private bool _isWorking = false;
    public bool IsWorking { get { return _isWorking; } set { _isWorking = value; } }

    public float SpeedBonus { set { _speedBonus = value; } }

    // Start is called before the first frame update
    private void Awake()
    {
        _plyInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
