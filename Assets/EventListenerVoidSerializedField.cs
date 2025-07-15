using UnityEngine;

namespace EventChannel {
public abstract class EventListenerVoidSerializedField : EventListenerVoid {
    [SerializeField]
    private EventChannelVoid channel;

    protected override IEventChannelVoid EventChannel() => channel;
}
}
