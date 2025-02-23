using Assets.Scripts.Bootstrap;
using UnityEngine;

namespace Core
{
    public class SceneBootstrap : MonoBehaviour
    {
        private SceneStateMachine _stateMachine;
        [SerializeField]
        private SceneInitializer _sceneInitializer;
        private void Awake()
        {
            _stateMachine = new SceneStateMachine();
            var args = new SceneInitializerArgs() 
            {
                SceneInitializer = _sceneInitializer
            };
            _stateMachine.EnterIn<LoadingSceneState>(args);

        }
    }
}
