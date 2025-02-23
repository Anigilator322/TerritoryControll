namespace Core.Enemy
{
    public interface IEnemyState
    {
        void Enter();
        void Exit();
        void LogicUpdate();
    }
}
