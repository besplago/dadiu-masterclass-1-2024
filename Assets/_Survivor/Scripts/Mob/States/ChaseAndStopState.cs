using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class ChaseAndStopState : ChaseState
    {
        public override void UpdateState(Mob mob)
        {
            if (mob is not MobDasher dasher) return;
            base.UpdateState(mob);

            if (Vector3.Distance(mob.transform.position, mob.Target.transform.position) <= dasher.Settings.attackRange)
            {
                mob.ChangeState(new TelegraphingState());
            }
        }
    }
}