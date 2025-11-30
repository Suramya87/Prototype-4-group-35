using UnityEngine;

namespace Project.StateMachine
{
	public abstract class State
	{
		protected GameObject _owner { get; private set; }

		public State(GameObject owner)
		{
			_owner = owner;
		}

		// Since states live as long as the state machine, either OnEnter() or OnExit() need to handle resetting the state
		public virtual void OnEnter() { }
		public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
    }
}
