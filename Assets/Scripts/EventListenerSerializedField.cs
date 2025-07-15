using UnityEngine;

namespace EventChannel {
public abstract class EventListenerSerializedField<T> : EventListener<T> {
    [SerializeField]
    private EventChannel<T> channel;

    protected override IEventChannel<T> EventChannel() => channel;
}
}
