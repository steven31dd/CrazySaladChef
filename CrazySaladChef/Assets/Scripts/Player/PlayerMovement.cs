using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerInput _plyInput;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] GameObject receiverGO;

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
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (_plyInput.Interact() && !_isWorking)
       {
                if(receiverGO != null)
                {
                Debug.Log("Send Message To Object");
                    receiverGO.SendMessage("OnInteract", gameObject, SendMessageOptions.DontRequireReceiver);
                }
       }
    }

    private void FixedUpdate()
    {
        if (_isWorking) return;

        Vector2 movement = _plyInput.Move().normalized;
        _rb.MovePosition(_rb.position + movement * (_speedBonus + _moveSpeed) * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Object Detected: " + collision.name);
        receiverGO = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited Detection: " + collision.name);
        receiverGO = null;
    }

}
