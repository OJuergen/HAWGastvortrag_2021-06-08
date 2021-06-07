using TMPro;
using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// Display health of an <see cref="ScriptableObjectEventMonster"/> in text form.
    /// </summary>
    public class ScriptableObjectEventHealthDisplay : MonoBehaviour
    {
        [SerializeField, Tooltip("Text to visualize health.")]
        private TMP_Text _text;
        [SerializeField, Tooltip("The event asset for monster-health changes.")]
        private MonsterHealthChangeEvent _monsterHealthChanged;

        // It's good practice to register event listeners in OnEnable and unregister in OnDisable.
        private void OnEnable()
        {
            _monsterHealthChanged += OnHealthChanged;
            // we cannot initialize the health display without a reference to the monster
        }

        private void OnDisable()
        {
            _monsterHealthChanged -= OnHealthChanged; // important to unregister!
        }

        private void OnHealthChanged(ScriptableObjectEventMonster source, int newHealth)
        {
            // it's good practice to wrap code in event handlers in a try-catch block. Otherwise, an exception will
            // prevent other event-listeners from being called, if they registered after this one.
            try
            {
                _text.text = $"{newHealth} / {source.MaximumHealth}";
            }
            catch
            {
                enabled = false; // when we are unable to handle events, we should deactivate
            }
        }
    }
}