using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class TelegraphingState : IMobState
    {
        private float _elapsedTime;
        private bool _telegraphing;


        public void EnterState(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            var directionToTarget = (dasher.Target.transform.position - dasher.transform.position).normalized;
            var dashTargetPosition =
                dasher.Target.transform.position + directionToTarget * dasher.Settings.extraDashLength;
            dasher.DashTargetPosition = dashTargetPosition;

            dasher.AttackTelegraph.PlayAttackTelegraphAnimation(dasher);
            _elapsedTime = 0f;
            _telegraphing = true;
        }

        public void UpdateState(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            if (!_telegraphing)
            {
                mob.ChangeState(new DashState());
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= dasher.Settings.dashTelegraphDuration)
                {
                    _telegraphing = false;
                }
            }
        }

        public void ExitState(Mob mob)
        {
        }
    }
}