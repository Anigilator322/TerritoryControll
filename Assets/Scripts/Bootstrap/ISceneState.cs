using Assets.Scripts.Bootstrap;

namespace Core
{
    public interface ISceneState
    {
        void Enter(SceneInitializerArgs args);
        void Exit();
    }
}
