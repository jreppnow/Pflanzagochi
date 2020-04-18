using Godot;
using System;

public class WateringCan : AnimatedSprite
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Show();
	}

	public override void _Process(float delta)
	{
		Position = GetViewport().GetMousePosition();
		if (Input.IsMouseButtonPressed((int) ButtonList.Left))
		{
			Animation = "pouring";
			Play();
		} else
		{
			Animation = "default";
			Stop();
		}
	}
}
