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
            if (mob is not MobDasher dasher) return;
            _dasherSettings = dasher.Settings as MobDasherSettings;
            var directionToTarget = (dasher.Target.transform.position - dasher.transform.position).normalized;
            if (_dasherSettings)
            {
                var dashTargetPosition =
                    dasher.Target.transform.position + directionToTarget * _dasherSettings.extraDashLength;
                dasher.DashTarget = dashTargetPosition;
            }

            dasher.AttackTelegraph.PlayAttackTelegraphAnimation(dasher);
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