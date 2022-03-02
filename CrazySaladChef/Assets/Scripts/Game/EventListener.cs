using UnityEngine;
using UnityEngine.Events;

//Listener for the event scriptable object
public class EventListener : MonoBehaviour
{
    public EventObject gameEvent;
    public UnityEvent onEventTriggered;
    void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
}

