using JetBrains.Annotations;

namespace EventChannel {
public interface IEventChannelVoid {
    void Fire();

    void Register([NotNull] EventListenerVoid listener);

    void Unregister([NotNull] EventListenerVoid listener);
}
}
