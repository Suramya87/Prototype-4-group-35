using UnityEngine;
using Project.StateMachine;

public class CollidingWithWallInDirection : Transition
{
	private readonly Vector2 _collisionDirection2D;
	private readonly Vector2 _raycastOffsetFromTransform2D;

    public CollidingWithWallInDirection(GameObject owner, Vector2 collisionDirection2D) : base(owner)
	{
		_collisionDirection2D = collisionDirection2D.normalized;

        var circleCollider2D = owner.GetComponent<CircleCollider2D>();
		Vector2 circleCollider2DOffsetScaled2D = circleCollider2D.offset * owner.transform.localScale.x;
		float circleCollider2DRadiusScaled = circleCollider2D.radius * owner.transform.localScale.x;
		_raycastOffsetFromTransform2D = circleCollider2DOffsetScaled2D + (collisionDirection2D * circleCollider2DRadiusScaled);
	}

	public override bool CanTransition()
	{
		Vector3 origin = (Vector2)_owner.transform.position + _raycastOffsetFromTransform2D;
		RaycastHit2D hit = Physics2D.Raycast(origin, _collisionDirection2D, 0.1f);
		return hit && hit.collider.CompareTag("Wall");
    }
}
