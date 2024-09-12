namespace _Survivor.Scripts.Mob
{
    public class MobDasherShort : Mob
    {
        protected override void Start()
        {
            base.Start();

            CurrentState = new ChaseAndStopState();
        }
    }
}