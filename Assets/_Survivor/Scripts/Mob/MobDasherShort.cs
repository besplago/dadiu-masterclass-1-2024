using _Survivor.Scripts.Mob.States;

namespace _Survivor.Scripts.Mob
{
    public class MobDasherShort : MobDasher
    {
        protected override void Start()
        {
            base.Start();

            CurrentState = new ChaseAndStopState();
        }
    }
}