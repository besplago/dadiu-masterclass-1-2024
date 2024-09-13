using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts
{
    [CreateAssetMenu(menuName = "Gameplay/CharacterMotorSettings")]
    public class HeroMotorSettings : ScriptableObject
    {
        [FormerlySerializedAs("MaxSpeed")] public float maxSpeed = 10;

        [FormerlySerializedAs("Accelleration")]
        public float acceleration = 5;

        public float dashTime = 0.2f;
        public float dashSpeedMultiplier = 2f;
        public float dashCooldown = 1f;
    }
}