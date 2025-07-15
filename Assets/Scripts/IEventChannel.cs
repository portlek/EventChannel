using JetBrains.Annotations;

namespace EventChannel {
public interface IEventChannel<TContext> {
    void Fire([NotNull] TContext e);

    void Register([NotNull] EventListener<TContext> listener);

    void Unregister([NotNull] EventListener<TContext> listener);
}
}
