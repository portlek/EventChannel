using System.Collections.Generic;
using UnityEngine;

namespace EventChannel {
public abstract class EventChannelVoid : ScriptableObject, IEventChannelVoid {
    private readonly ISet<EventListenerVoid> listeners =
        new HashSet<EventListenerVoid>();

    public void Fire() {
        foreach (var listener in listeners) {
            listener.Raise();
        }
    }

    public void Register(EventListenerVoid listener) {
        listeners.Add(listener);
    }

    public void Unregister(EventListenerVoid listener) {
        listeners.Remove(listener);
    }
}
}
