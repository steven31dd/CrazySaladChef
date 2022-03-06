using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] GameObject receiverGO;

    public GameObject DetectedObject { get { return receiverGO; } }

    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object Detected: " + collision.name);
        receiverGO = collision.gameObject;
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
