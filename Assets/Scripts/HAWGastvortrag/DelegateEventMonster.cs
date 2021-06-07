namespace HAWGastvortrag
{
    /// <summary>
    /// This is an implementation of a <see cref="Monster"/> that can take damage.
    /// This monster uses delegates for events with named parameters.
    /// </summary>
    public class DelegateEventMonster : Monster
    {
        /// <summary>
        /// Type of listeners for health-change events.
        /// Delegates allow us to name parameters and add documentation.
        /// It's good practice to pass the source object as the first parameter.
        /// Microsoft recommends to use an EventParam class that wraps all parameters, but that is a lot of boilerplate.
        /// </summary>
        public delegate void HealthChangeDelegate(Monster monster, int newHealth);

        /// <summary>
        /// Event raised when Monster health changed.
        /// Delegate events are the cleanest and fastest approach to events without external packages.
        /// </summary>
        public event HealthChangeDelegate HealthChanged;

        protected override void OnHealthChanged()
        {
            HealthChanged?.Invoke(this, CurrentHealth);
        }
    }
}