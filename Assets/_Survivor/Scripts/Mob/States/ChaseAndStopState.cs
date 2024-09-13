using UnityEngine;

namespace _Survivor.Scripts.Mob.States
{
    public class ChaseAndStopState : ChaseState
    {
        private MobDasherSettings _dasherSettings;

        public override void EnterState(Mob mob)
        {
            base.EnterState(mob);
            _dasherSettings = mob.Settings as MobDasherSettings;
        }

        public override void UpdateState(Mob mob)
        {
            base.UpdateState(mob);

            if (Vector3.Distance(mob.transform.position, mob.Target.transform.position) <= _dasherSettings.attackRange)
            {
                mob.ChangeState(new TelegraphingState());
            }
        }
    }
}