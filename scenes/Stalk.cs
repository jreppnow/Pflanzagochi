using Godot;
using System;

public class Stalk : Area2D
{
	public Vector2 HitboxExtends
	{
		get { return (GetNode<CollisionShape2D>("CollisionShape2D").Shape as RectangleShape2D).Extents;  }
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public Vector2 ComputeNextLocation()
	{
		return Position + HitboxExtends.Rotated(Rotation);
	}

	public Vector2 ComputeLocation(Vector2 attachedLocation)
	{
		return attachedLocation + HitboxExtends.Rotated(Rotation);
	}
}
