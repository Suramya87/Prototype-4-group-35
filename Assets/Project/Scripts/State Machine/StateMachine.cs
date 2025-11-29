using System.Collections.Generic;
using UnityEngine;

namespace Project.StateMachine
{
	public class StateMachine : MonoBehaviour
	{
		protected Dictionary<State, List<(Transition, State)>> _stateTransitions;
		private State _currentState;

		public void SetState(State state)
		{
			_currentState?.OnExit();
			_currentState = state;
			_currentState.OnEnter();
		}

		private void Update()
		{
			if (_currentState == null)
			{
				return;
			}

			List<(Transition, State)> transitions = _stateTransitions[_currentState];
			foreach (var (transition, state) in transitions)
			{
				if (transition.CanTransition())
				{
					SetState(state);
					break;
				}
			}

			_currentState.OnUpdate();
		}

        private void FixedUpdate()
        {
            if (_currentState == null)
            {
                return;
            }

            _currentState.OnFixedUpdate();
        }
    }
}

