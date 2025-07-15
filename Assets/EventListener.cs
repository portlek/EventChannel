using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace EventChannel {
public abstract class EventListener<T> : MonoBehaviour {
    [SerializeField]
    private UnityEvent<T> unityEvent;

    private void OnEnable() {
        EventChannel().Register(this);
    }

    private void OnDisable() {
        EventChannel().Unregister(this);
    }

    public void Raise([NotNull] T e) {
        unityEvent?.Invoke(e);
    }

    [NotNull]
    protected abstract IEventChannel<T> EventChannel();
}
}
