namespace _Survivor.Scripts.Mob
{
    public interface IMobState
    {
        void EnterState(Scripts.Mob.Mob mob);
        void UpdateState(Scripts.Mob.Mob mob);
        void ExitState(Scripts.Mob.Mob mob);
    }
}