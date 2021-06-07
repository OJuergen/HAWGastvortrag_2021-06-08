using System;
using UniRx;

namespace HAWGastvortrag
{
    /// <summary>
    /// This is an implementation of a <see cref="Monster"/> that can take damage.
    /// This monster uses UniRx subjects as events. UniRx is a library that wraps the popular reactive library for
    /// Unity. Reactive is used to handle streams of data and is very powerful. It can be used to handle events and
    /// has a few advantages over traditional events, like easier unsubscribing. See <see cref="RxHealthDisplay"/>.
    /// </summary>
    public class RxEventMonster : Monster
    {
        // we use a subject to create a data stream from events. Subjects can only use one parameter, so we
        // use a tuple to wrap data. We could also use a custom class or struct.
        private readonly Subject<(Monster monster, int newHealth)>
            _healthChangedSubject = new Subject<(Monster, int)>();

        // we expose an observable that acts like an event emitter where listeners can subscribe to
        public IObservable<(Monster monster, int newHealth)> HealthChanged => _healthChangedSubject;

        protected override void OnHealthChanged()
        {
            _healthChangedSubject.OnNext((this, CurrentHealth));
        }
    }
}