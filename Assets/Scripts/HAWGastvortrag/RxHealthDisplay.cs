using TMPro;
using UniRx;
using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// Display health of a <see cref="RxEventMonster"/> in text form.
    /// </summary>
    public class RxHealthDisplay : MonoBehaviour
    {
        [SerializeField, Tooltip("Text to visualize health.")]
        private TMP_Text _text;
        [SerializeField, Tooltip("The monster whose health is visualized.")]
        private RxEventMonster _monster;

        private void Awake()
        {
            // Subscribing is very simple. We can even use lambda functions for really compact code.
            // The AddTo(this) call will handle unsubscribing in case this object is destroyed.
            _monster.HealthChanged
                .Subscribe(args => _text.text = $"{args.newHealth} / {args.monster.MaximumHealth}")
                .AddTo(this);
        }
    }
}