using UnityEngine;

namespace HAWGastvortrag
{
    /// <summary>
    /// A simple debug UI displaying utility buttons on the screen.
    /// Use this for debugging and testing purposes only.
    /// </summary>
    public class DebugIMGUI : MonoBehaviour
    {
        [SerializeField, Tooltip("The monster to deal damage to")]
        private Monster _monster;

        private void Awake()
        {
            // Validate state and deactivate here. This is better for performance than checking the _monster variable every frame.
            if (_monster == null)
            {
                Debug.LogWarning("Deactivating Debug IMGUI, because monster is not set.");
                gameObject.SetActive(false);
            }
        }

        private void OnGUI()
        {
            if (_monster.CurrentHealth > 0 && GUILayout.Button("Deal one damage"))
            {
                _monster.TakeDamage(1);
            }
        }
    }
}