using System.Collections.Generic;
using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    [RequireComponent(typeof(CharacterController))]
    public class Mob : MonoBehaviour
    {
        public static readonly List<Mob> Actives = new();

        [SerializeField] private MobSettings settings;

        private IMobState _currentState;

        public IMobState CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState == value) return;
                _currentState?.ExitState(this);
                _currentState = value;
                _currentState.EnterState(this);
            }
        }

        public CharacterController Controller { get; private set; }

        public Hero Target { get; private set; }
        public Vector3 DashTarget { get; set; }

        public MobSettings Settings => settings;

        public AttackTelegraph AttackTelegraph { get; private set; }

        private void Start()
        {
            Controller = GetComponent<CharacterController>();
            Target = FindAnyObjectByType<Hero>();
            DashTarget = Target.transform.position;
            AttackTelegraph = GetComponentInChildren<AttackTelegraph>();

            CurrentState = new ChaseState();
        }

        private void OnEnable()
        {
            Actives.Add(this);
        }

        private void OnDisable()
        {
            Actives.Remove(this);
        }

        private void Update()
        {
            if (!Target) return;

            _currentState?.UpdateState(this);
        }

        public void ChangeState(IMobState newState)
        {
            CurrentState = newState;
        }
    }
}