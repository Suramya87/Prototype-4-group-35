using Project.StateMachine;
using UnityEngine;

public class TooFarRight : Transition
{
	public TooFarRight(GameObject owner) : base(owner) { }

	public override bool CanTransition()
	{
		return _owner.transform.position.x > 5;
	}
}
