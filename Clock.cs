using Godot;
using System;

public class Clock : Sprite
{
	[Signal]
	public delegate void UpdateTime(int hour);

	private int time = 0;
	private Texture clock0;
	private Texture clock3;
	private Texture clock6;
	private Texture clock9;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		clock0 = (Texture) GD.Load("res://assets/clock_placeholder_0.jpg"); // Godot loads the Resource when it reads the line.
		clock3 = (Texture) GD.Load("res://assets/clock_placeholder_3.jpg"); // Godot loads the Resource when it reads the line.
		clock6 = (Texture) GD.Load("res://assets/clock_placeholder_6.jpg"); // Godot loads the Resource when it reads the line.
		clock9 = (Texture) GD.Load("res://assets/clock_placeholder_9.jpg"); // Godot loads the Resource when it reads the line.

		Texture = clock0;
	}

	private Texture GetTexture(int time)
	{
		time %= 11;
		if (time < 3 || time > 11)
		{
			return clock0;
		} else if (time < 6)
		{
			return clock3;
		} else if (time < 9)
		{
			return clock6;
		} else
		{
			return clock9;
		}
	}

	private void OnTimeUpdate()
	{
		time = (time + 1) % 23;
		GD.Print("Update time to ", time, " o'clock..");
		EmitSignal("UpdateTime", time);
		Texture = GetTexture(time);
	}
}

