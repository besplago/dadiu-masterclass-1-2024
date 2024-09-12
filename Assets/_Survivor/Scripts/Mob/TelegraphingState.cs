using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class TelegraphingState : IMobState
    {
        private float _elapsedTime;
        private bool _telegraphing;

        public void EnterState(Mob mob)
        {
            var directionToTarget = (mob.Target.transform.position - mob.transform.position).normalized;
            var dashTargetPosition =
                mob.Target.transform.position + directionToTarget * mob.Settings.extraTelegraphLength;
            mob.DashTarget = dashTargetPosition;

            mob.AttackTelegraph.PlayAttackTelegraphAnimation(mob);
            _elapsedTime = 0f;
            _telegraphing = true;
        }

        public void UpdateState(Mob mob)
        {
            if (!_telegraphing)
            {
                mob.ChangeState(new AttackState());
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= mob.Settings.attackTelegraphDuration)
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