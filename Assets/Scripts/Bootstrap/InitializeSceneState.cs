using Assets.Scripts.Bootstrap;
using Assets.Scripts.Point.Spawn;
using Core.Units;
using Core.Units.Spawn;
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

        public void Enter(SceneInitializerArgs args)
        {
            Debug.Log("Enter Initialize");
            args.SceneInitializer.Initialize();
        }

        public void Exit()
        {
            Debug.Log("Exit Initialize");
        }
    }
}
