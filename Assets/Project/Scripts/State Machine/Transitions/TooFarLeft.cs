using Project.StateMachine;
using UnityEngine;

public class TooFarLeft : Transition
{
	public TooFarLeft(GameObject owner) : base(owner) { }

	public override bool CanTransition()
	{
		return _owner.transform.position.x < -5;
	}
}
