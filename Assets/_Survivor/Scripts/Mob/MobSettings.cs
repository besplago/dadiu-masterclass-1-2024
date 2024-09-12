using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts.Mob
{
    [CreateAssetMenu(menuName = "Game/MobSettings")]
    public class MobSettings : ScriptableObject
    {
        [FormerlySerializedAs("MoveSpeed")] public float moveSpeed;
        [FormerlySerializedAs("Acceleration")] public float acceleration;
    }
}