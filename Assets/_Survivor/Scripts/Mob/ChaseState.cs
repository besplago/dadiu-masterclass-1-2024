using UnityEngine;

namespace _Survivor.Scripts.Mob
{
    public class ChaseState : IMobState
    {
        public virtual void EnterState(Mob mob)
        {
        }

        public virtual void UpdateState(Mob mob)
        {
            if (!mob.Target) return;

            var delta = mob.Target.transform.position - mob.transform.position;
            var distance = delta.magnitude;

            if (distance <= 0) return;

            var motion = delta.normalized * (Time.deltaTime * mob.Settings.moveSpeed);
            mob.Controller.Move(motion);
        }

        public void ExitState(Mob mob)
        {
        }
    }
}