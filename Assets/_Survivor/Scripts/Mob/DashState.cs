﻿using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class DashState : IMobState
    {
        private const float TargetProximityThreshold = 1f;
        private bool _accelerating = true;
        private float _dashSpeed;
        private MobDasherSettings _dasherSettings;

        public void EnterState(Mob mob)
        {
            _dasherSettings = mob.Settings as MobDasherSettings;
            _dashSpeed = 0f;
            _accelerating = true;
        }

        public void UpdateState(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            DashMovement(dasher);

            if (Vector3.Distance(dasher.transform.position, dasher.DashTarget) <= TargetProximityThreshold)
            {
                dasher.ChangeState(new CooldownState());
            }
        }

        public void ExitState(Mob mob)
        {
        }

        private void DashMovement(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            var direction = (dasher.DashTarget - dasher.transform.position).normalized;

            if (_accelerating)
            {
                _dashSpeed += _dasherSettings.dashAcceleration * Time.deltaTime;
                if (_dashSpeed >= _dasherSettings.dashMaxSpeed)
                {
                    _dashSpeed = _dasherSettings.dashMaxSpeed;
                    _accelerating = false;
                }
            }
            else
            {
                if (Vector3.Distance(dasher.transform.position, dasher.DashTarget) <= _dasherSettings.dashMaxSpeed * Time.deltaTime)
                {
                    _dashSpeed -= _dasherSettings.dashDeceleration * Time.deltaTime;
                    if (_dashSpeed <= 0f)
                    {
                        _dashSpeed = 0f;
                    }
                }
            }

            dasher.transform.position += direction * (_dashSpeed * Time.deltaTime);
        }
    }
}