using Project.StateMachine;
using UnityEngine;

public class TooFarUp : Transition
{
	public TooFarUp(GameObject owner) : base(owner) { }

	public override bool CanTransition()
	{
		return _owner.transform.position.y > 5;
	}
}
