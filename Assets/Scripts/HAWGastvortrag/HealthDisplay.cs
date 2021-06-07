using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// A controller component for the visualization of health of a <see cref="UnityEventMonster"/>.
    /// </summary>
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField, Tooltip("Text component to display health")] private TMP_Text _text;

        /// <summary>
        /// Update the health values to display. Must be public to be accessible for UnityEvent.
        /// </summary>
        /// <param name="monster">The monster whose health is displayed.</param>
        /// <param name="currentHealth">The current health of the monster.</param>
        public void OnHealthChanged(Monster monster, int currentHealth)
        {
            if (_text == null)
            {
                Debug.LogWarning("No text component available.");
                return;
            }
            _text.text = $"{currentHealth} / {monster.MaximumHealth}";
        }

        /// <summary>
        /// Update the health values to display. Must be public to be accessible for UnityEvent.
        /// </summary>
        /// <param name="parameters">event parameters as a value tuple</param>
        [UsedImplicitly] // used from UnityEvent
        public void OnHealthChanged((Monster monster, int current) parameters)
        {
            OnHealthChanged(parameters.monster, parameters.current);
        }
    }
} 
