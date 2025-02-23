using UnityEngine;

namespace Core
{
    public class SceneBootstrap : MonoBehaviour
    {
        private SceneStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new SceneStateMachine();

            _stateMachine.EnterIn<LoadingSceneState>();

        }
    }
}
