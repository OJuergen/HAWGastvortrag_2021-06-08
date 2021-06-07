using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// This is a very simple implementation of a <see cref="Monster"/> that can take and display damage.
    /// This monster actively controls the <see cref="HealthDisplay"/> to show the current health.
    /// </summary>
    public class SimpleMonster : Monster
    {
        [SerializeField, Tooltip("The visualization of the current and maximum health")]
        private HealthDisplay _healthDisplay;

        protected override void OnHealthChanged()
        {
            if(_healthDisplay != null) _healthDisplay.OnHealthChanged(this, CurrentHealth);
        }
    }
}