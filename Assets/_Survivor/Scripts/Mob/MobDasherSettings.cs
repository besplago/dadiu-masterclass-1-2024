using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    [CreateAssetMenu(menuName = "Game/MobDasherSettings")]
    public class MobDasherSettings : MobSettings
    {
        [SerializeField] public float attackTelegraphDuration;
        [SerializeField] public float extraTelegraphLength;
        [SerializeField] public float attackAcceleration;
        [SerializeField] public float attackDeceleration;
        [SerializeField] public float attackMaxSpeed;
    }
}