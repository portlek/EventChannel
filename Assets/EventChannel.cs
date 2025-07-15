using System.Collections.Generic;
using UnityEngine;

namespace EventChannel {
public abstract class EventChannel<TContext> : ScriptableObject, IEventChannel<TContext> {
    private readonly ISet<EventListener<TContext>> _listeners =
        new HashSet<EventListener<TContext>>();

    public void Fire(TContext e) {
        foreach (var listener in _listeners) {
            listener.Raise(e);
        }
    }

    public void Register(EventListener<TContext> listener) {
        _listeners.Add(listener);
    }

    public void Unregister(EventListener<TContext> listener) {
        _listeners.Remove(listener);
    }
}
}
