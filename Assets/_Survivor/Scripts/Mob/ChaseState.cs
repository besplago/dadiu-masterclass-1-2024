using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class ChaseState : IMobState
    {
        public void EnterState(Scripts.Mob.Mob mob)
        {
        }

        public void UpdateState(Scripts.Mob.Mob mob)
        {
            if (!mob.Target) return;

            var delta = mob.Target.transform.position - mob.transform.position;
            if (delta.magnitude <= 0) return;

            var motion = delta.normalized * (Time.deltaTime * mob.Settings.MoveSpeed);
            mob.Controller.Move(motion);
        }

        public void ExitState(Scripts.Mob.Mob mob)
        {
        }
    }
}