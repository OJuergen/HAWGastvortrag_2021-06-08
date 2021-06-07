using UnityEngine;

namespace HAWGastvortrag
{
    [CreateAssetMenu(menuName = "ScriptableObject event/monster health change")]
    public class MonsterHealthChangeEvent : ScriptableObjectEvent<MonsterHealthChangeEvent, ScriptableObjectEventMonster, int>
    { }
}