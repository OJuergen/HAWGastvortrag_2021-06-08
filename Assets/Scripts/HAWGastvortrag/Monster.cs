using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// Base class for Monsters that have a health value and can take damage.
    /// </summary>
    public abstract class Monster : MonoBehaviour
    {
        // fields should ALWAYS be private/protected. USe SerializeField attribute to expose to editor.
        [SerializeField, Tooltip("The maximum health of the monster.")]
        private int _maximumHealth;
        
        /// <summary>
        /// The maximum health of the Monster.
        /// </summary>
        public int MaximumHealth => _maximumHealth; // public property to grant read-only access
        
        /// <summary>
        /// The current health of the Monster.
        /// </summary>
        public int CurrentHealth { get; private set; }
        
        private void Awake()
        {
            if (MaximumHealth <= 0)
            {
                Debug.LogWarning("Cannot initialize monster: maximum health must be larger than zero, " +
                                 $"but was {MaximumHealth}. Disabling monster.", this);
                gameObject.SetActive(false);
                return;
            }

            CurrentHealth = MaximumHealth;
            OnHealthChanged();
        }
        

        /// <summary>
        /// The monster takes a given amount of damage, reducing the current health. Monster must still be alive.
        /// </summary>
        /// <param name="amount">The amount of damage. Must be larger than zero.</param>
        public void TakeDamage(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning($"Cannot take damage: must be larger than zero, but was {amount}", this);
                return;
            }

            if (CurrentHealth == 0)
            {
                Debug.LogWarning("Cannot take damage: Monster is dead", this);
                return;
            }

            CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, MaximumHealth);
            Debug.Log($"Monster took {amount} damage", this);
            OnHealthChanged();

            if (CurrentHealth == 0)
            {
                Debug.Log("Monster died", this);
                Destroy(gameObject);
            }
        }

        protected abstract void OnHealthChanged();
        
        /// <summary>
        /// The attribute <see cref="ContextMenu"/> allows invoking the method through the editor context menu of the
        /// script. Super useful for debugging and quick testing 
        /// </summary>
        [ContextMenu("Take one damage")]
        private void TakeOneDamage()
        {
            TakeDamage(1);
        }
    }
}