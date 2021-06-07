using System;

namespace HAWGastvortrag
{
    /// <summary>
    /// This is an implementation of a <see cref="Monster"/> that can take damage.
    /// This monster is decoupled from the health display via events.
    /// </summary>
    public class EventMonster : Monster
    {
        /// <summary>
        /// Event raised when Monster health changed.
        /// The 'event' keyword keeps other scripts from invoking this event.
        /// The Action type is a generic type that can be used for events with or without parameters.
        /// </summary>
        public event Action<Monster, int> HealthChanged; // use past tense for events that report a change

        protected override void OnHealthChanged()
        {
            // Invoke event. Null-coalescing operator checks, if there are any listeners.
            HealthChanged?.Invoke(this, CurrentHealth); 
        }
    }
}