using Assets.Scripts.Bootstrap;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public class SceneStateMachine
    {
        private Dictionary<Type, ISceneState> _states;
        private ISceneState _currentState;

        public SceneStateMachine()
        {
            _states = new Dictionary<Type, ISceneState>()
            {
                [typeof(InitializeSceneState)] = new InitializeSceneState(this),
                [typeof(LoadingSceneState)] = new LoadingSceneState(this),
            };
        }
        
        public void EnterIn<TState>(SceneInitializerArgs args) where TState : ISceneState
        {
            if(_states.TryGetValue(typeof(TState), out ISceneState state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter(args);
            }
        }
        public void AddState(ISceneState state)
        {
            Type type = state.GetType();
            if(_states.ContainsKey(type)==false)
            {
                _states.Add(type, state);
            }

        }
    }
}
