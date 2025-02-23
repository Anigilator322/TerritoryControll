using UnityEngine;

namespace Core
{
    public class LoadingSceneState : ISceneState
    {
        private readonly SceneStateMachine _sceneStateMachine;

        public LoadingSceneState(SceneStateMachine stateMachine)
        {
            _sceneStateMachine = stateMachine;
        }
        public void Enter()
        {
            Debug.Log("Enter Loading");
            _sceneStateMachine.EnterIn<InitializeSceneState>();
        }

        public void Exit()
        {
            Debug.Log("Exit Loading");
        }
    }
}
