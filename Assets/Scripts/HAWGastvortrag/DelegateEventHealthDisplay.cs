using TMPro;
using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// Display health of a <see cref="DelegateEventMonster"/> in text form.
    /// </summary>
    public class DelegateEventHealthDisplay : MonoBehaviour
    {
        [SerializeField, Tooltip("Text to visualize health.")] private TMP_Text _text;
        [SerializeField, Tooltip("The monster whose health is visualized.")] private DelegateEventMonster _monster;
        
        private void OnEnable()
        {
            _monster.HealthChanged += OnHealthChanged; // register event listener
            OnHealthChanged(_monster, _monster.CurrentHealth);
        }

        private void OnDisable()
        {
            _monster.HealthChanged -= OnHealthChanged; // important to unregister!
        }

        private void OnHealthChanged(Monster monster, int newHealth)
        {
            _text.text = $"{newHealth} / {monster.MaximumHealth}";
        }
    }
} 
