using UnityEngine;
using UnityEngine.Events;

namespace HAWGastvortrag
{
    /// <summary>
    /// This is an implementation of a <see cref="Monster"/> that can take damage.
    /// This monster uses Unity events to notify listeners of health changes.
    /// </summary>
    public class UnityEventMonster : Monster
    {
        /// <summary>
        /// Event raised when Monster health changed.
        /// This event can be connected to functions via the editor.
        /// Unfortunately, we cannot name the parameters.
        /// This is comfortable to use and there is no coupling between scripts in the code at all.
        /// However, UnityEvent is rather slow and it is very hard to find registered listeners, making debugging hard.
        /// We cannot protect this with the event keyword, so make sure to keep it private.
        /// You can add listeners in runtime with AddListener, but they will not appear in the editor.
        /// </summary>
        [SerializeField] private UnityEvent<Monster, int> HealthChanged;

        /// <summary>
        /// This UnityEvent takes one parameter that is a tuple of multiple named values.
        /// This can be used to name parameters of a unity event.
        /// </summary>
        [SerializeField] private UnityEvent<(Monster monster, int newHealth)> HealthChangedTuple;

        protected override void OnHealthChanged()
        {
            HealthChanged?.Invoke(this, CurrentHealth);
            HealthChangedTuple?.Invoke((this, CurrentHealth));
        }
    }
}