using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace EventChannel {
public abstract class EventListenerVoid : MonoBehaviour {
    [SerializeField]
    private UnityEvent unityEvent;

    private void OnEnable() {
        EventChannel().Register(this);
    }

    private void OnDisable() {
        EventChannel().Unregister(this);
    }

    public void Raise() {
        unityEvent?.Invoke();
    }

    [NotNull]
    protected abstract IEventChannelVoid EventChannel();
}
}
