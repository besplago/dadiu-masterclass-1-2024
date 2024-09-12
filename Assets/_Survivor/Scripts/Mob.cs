using System.Collections.Generic;
using UnityEngine;

namespace _Survivor.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Mob : MonoBehaviour
    {
        public static readonly List<Mob> Actives = new List<Mob>();


        [SerializeField] private MobSettings settings;

        private CharacterController _controller;

        private Hero _target;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _target = Object.FindAnyObjectByType<Hero>();
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
            if (!_target) return;
            var delta = _target.transform.position - transform.position;
            if (!(delta.magnitude > 0)) return;
            var motion = delta.normalized * (Time.deltaTime * settings.MoveSpeed);
            _controller.Move(motion);
        }
    }
}