namespace _Survivor.Scripts
{
    public interface IMobState
    {
        void EnterState(Mob mob);
        void UpdateState(Mob mob);
        void ExitState(Mob mob);
    }
}