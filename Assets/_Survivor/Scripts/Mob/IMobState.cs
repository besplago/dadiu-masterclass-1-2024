namespace _Survivor.Scripts.Mob
{
    public interface IMobState
    {
        void EnterState(Mob mob);
        void UpdateState(Mob mob);
        void ExitState(Mob mob);
    }
}