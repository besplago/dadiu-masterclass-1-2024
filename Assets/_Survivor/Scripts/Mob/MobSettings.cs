using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    [CreateAssetMenu(menuName = "Game/MobSettings")]
    public class MobSettings : ScriptableObject
    {
        public float MoveSpeed;
        public float Acceleration;
    }
}
