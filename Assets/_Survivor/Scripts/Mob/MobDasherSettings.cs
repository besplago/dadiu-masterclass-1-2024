using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts.Mob
{
    [CreateAssetMenu(menuName = "Game/MobDasherSettings")]
    public class MobDasherSettings : MobSettings
    {
        [FormerlySerializedAs("attackTelegraphDuration")] [SerializeField] public float dashTelegraphDuration;
        [FormerlySerializedAs("extraTelegraphLength")] [SerializeField] public float extraDashLength;
        [FormerlySerializedAs("attackAcceleration")] [SerializeField] public float dashAcceleration;
        [FormerlySerializedAs("attackDeceleration")] [SerializeField] public float dashDeceleration;
        [FormerlySerializedAs("attackMaxSpeed")] [SerializeField] public float dashMaxSpeed;
        [SerializeField] public float attackRange;
    }
}