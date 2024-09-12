using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts.Mob
{
    [CreateAssetMenu(menuName = "Game/MobSettings")]
    public class MobSettings : ScriptableObject
    {
        [FormerlySerializedAs("MoveSpeed")] public float moveSpeed;
        [FormerlySerializedAs("Acceleration")] public float acceleration;
        [SerializeField] public float attackRange;

        [FormerlySerializedAs("attackTelegraphTime")] [SerializeField]
        public float attackTelegraphDuration;

        [SerializeField] public float extraTelegraphLength;
        [SerializeField] public float attackAcceleration;
        [SerializeField] public float attackDeceleration;
        [SerializeField] public float attackMaxSpeed;
    }
}