using Godot;
using System;

public class WateringCan : AnimatedSprite
{
	[Signal]
	public delegate void Pouring(Vector2 location);
	[Signal]
	public delegate void StoppedPouring();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Show();
	}

	public override void _Process(float delta)
	{
		Vector2 oldPosition = Position;
		bool wasPouring = IsPlaying();
		Position = GetViewport().GetMousePosition();
		if (Input.IsMouseButtonPressed((int) ButtonList.Left))
		{
			if (oldPosition != Position || !wasPouring)
			{
				EmitSignal("Pouring", Position);	
				if (!wasPouring)
				{
					GD.Print("Started pouring at location ", Position, ".");
					Animation = "pouring";
					Play();
				}
			}
		} else
		{
			if (wasPouring)
			{
				EmitSignal("StoppedPouring");
				GD.Print("Stopped pouring at location ", Position, ".");
				Animation = "default";
				Stop();
			}
		}
	}
}
