using UnityEngine;

namespace Core
{
    public class InitializeSceneState : ISceneState
    {
        private readonly SceneStateMachine _sceneStateMachine;
        /// <summary>
        /// TODO: Make Instantiating and Initializing Points by PointFactory
        /// </summary>

        public InitializeSceneState(SceneStateMachine sceneStateMachine)
        {
            
            _sceneStateMachine = sceneStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter Initialize");
        }

        public void Exit()
        {
            Debug.Log("Exit Initialize");
        }
    }
}
