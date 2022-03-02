using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Interaction for all interactables
/// </summary>
public abstract class BaseInteraction : MonoBehaviour
{
    public abstract void OnInteract(GameObject player);

    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }
}
