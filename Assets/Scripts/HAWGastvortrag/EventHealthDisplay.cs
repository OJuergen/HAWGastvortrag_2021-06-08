using TMPro;
using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// Display health of an <see cref="EventMonster"/> in text form.
    /// </summary>
    public class EventHealthDisplay : MonoBehaviour
    {
        [SerializeField, Tooltip("Text to visualize health.")] private TMP_Text _text;
        [SerializeField, Tooltip("The monster whose health is visualized.")] private EventMonster _monster;

        // It's good practice to register event listeners in OnEnable and unregister in OnDisable.
        private void OnEnable()
        {
            _monster.HealthChanged += OnHealthChanged; // register event listener
            OnHealthChanged(_monster, _monster.CurrentHealth); // call change listener once for initialization
        }

        private void OnDisable()
        {
            _monster.HealthChanged -= OnHealthChanged; // important to unregister!
        }

        private void OnHealthChanged(Monster monster, int newHealth)
        {
            // it's good practice to wrap code in event handlers in a try-catch block. Otherwise, an exception will
            // prevent other event-listeners from being called, if they registered after this one.
            try
            {
                _text.text = $"{newHealth} / {_monster.MaximumHealth}";
            }
            catch
            {
                enabled = false; // when we are unable to handle events, we should deactivate
            }
        }
    }
} 
