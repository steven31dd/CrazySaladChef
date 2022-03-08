using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] Transform target;
    [SerializeField] float timeEnd = 1.0f;
    

    public void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void InitPopUp(Item newItem, Transform newTarget)
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = newItem.image;
        target = newTarget;
        Invoke("TimeOut", timeEnd);
    }

    public void InitPopUp(Sprite sprite, Transform newTarget)
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = sprite;
        target = newTarget;
        Invoke("TimeOut", timeEnd);
    }

    private void Update()
    {
        if (target == null) return;

        transform.position = new Vector3(target.position.x, target.position.y + 0.3f, target.position.z);
    }

    public void TimeOut()
    {
        target = null;
        spriteRend.sprite = null;
        Destroy(gameObject);
    }
}
