using UnityEngine;
using UnityEngine.Serialization;

namespace _Survivor.Scripts
{
    [RequireComponent(typeof(HeroMotor))]
    public class Hero : MonoBehaviour
    {
        public static System.Action<Hero, float> DamageTaken;


        [FormerlySerializedAs("_health")] [SerializeField]
        private Health health;

        private HeroMotor _motor;

        public Health Health => health;

        public static Hero Instance;

        private void Awake()
        {
            Instance = this;

            _motor = GetComponent<HeroMotor>();

            health.Died.AddListener(() => { _motor.enabled = false; });

            health.DamageTaken.AddListener(args => { DamageTaken?.Invoke(this, args.CurrentRatio); });
        }

        private void Start()
        {
            DamageTaken?.Invoke(this, health.CurrentHealth);
        }

        public void Teleport(Vector3 position, Quaternion rotation)
        {
            _motor.Teleport(position, rotation);
        }
    }
}