using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class CooldownState : IMobState
    {
        private const float CooldownTime = 3f;
        private float _elapsedTime = 0f;

        public void EnterState(Mob mob)
        {
            _elapsedTime = 0f;
        }

        public void UpdateState(Mob mob)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= CooldownTime)
            {
                mob.ChangeState(new ChaseState());
            }
        }

        public void ExitState(Mob mob)
        {
        }
    }
}