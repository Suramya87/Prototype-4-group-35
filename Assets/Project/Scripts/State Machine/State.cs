using UnityEngine;

namespace Project.StateMachine
{
	public abstract class State
	{
		protected GameObject _owner;

		public State(GameObject owner)
		{
			_owner = owner;
		}

		// Since states live as long as the state machine, either OnEnter() or OnExit() need to handle resetting the state
		public abstract void OnEnter();
		public abstract void OnExit();
		public abstract void OnUpdate();
	}
}
