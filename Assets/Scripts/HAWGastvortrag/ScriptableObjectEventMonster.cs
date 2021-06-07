using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// This is an implementation of a <see cref="Monster"/> that can take damage.
    /// This monster uses a scriptable object for events.
    /// </summary>
    public class ScriptableObjectEventMonster : Monster
    {
        [SerializeField, Tooltip("The event asset to report health changes to.")]
        private MonsterHealthChangeEvent _healthChangedEvent;

        protected override void OnHealthChanged()
        {
            if (_healthChangedEvent != null) _healthChangedEvent.Invoke(this, CurrentHealth);
        }
    }
}