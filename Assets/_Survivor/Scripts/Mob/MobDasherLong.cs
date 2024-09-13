namespace _Survivor.Scripts.Mob
{
    public class MobDasherLong : MobDasher
    {
        protected override void Start()
        {
            base.Start();
            
            CurrentState = new TelegraphingState();
        }
    }
}