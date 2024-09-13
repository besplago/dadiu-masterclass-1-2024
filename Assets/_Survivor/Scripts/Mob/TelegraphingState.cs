using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class TelegraphingState : IMobState
    {
        private float _elapsedTime;
        private bool _telegraphing;
        
        private MobDasherSettings _dasherSettings;

        public void EnterState(Mob mob)
        {
            _dasherSettings = mob.Settings as MobDasherSettings;
            var directionToTarget = (mob.Target.transform.position - mob.transform.position).normalized;
            if (_dasherSettings)
            {
                var dashTargetPosition =
                    mob.Target.transform.position + directionToTarget * _dasherSettings.extraDashLength;
                mob.DashTarget = dashTargetPosition;
            }

            mob.AttackTelegraph.PlayAttackTelegraphAnimation(mob);
            _elapsedTime = 0f;
            _telegraphing = true;
        }

        public void UpdateState(Mob mob)
        {
            if (!_telegraphing)
            {
                mob.ChangeState(new DashState());
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _dasherSettings.dashTelegraphDuration)
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