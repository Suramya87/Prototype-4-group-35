using UnityEngine;

namespace Project.StateMachine
{
	public abstract class Transition
	{
		protected GameObject _owner { get; private set; }

		public Transition(GameObject owner)
		{
			_owner = owner;
		}

		public abstract bool CanTransition();
	}
}
