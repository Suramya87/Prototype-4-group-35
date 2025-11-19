using Project.StateMachine;
using UnityEngine;

public class TooFarDown : Transition
{
	public TooFarDown(GameObject owner) : base(owner) { }

	public override bool CanTransition()
	{
		return _owner.transform.position.y < -5;
	}
}
