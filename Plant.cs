using Godot;
using System;

public class Plant : Sprite
{
	[Signal]
	public delegate void UpdateTime(int hour);

	private int time = 0;
	private Texture plant1;
	private Texture plant2;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		plant1 = (Texture)GD.Load("res://assets/plant1.png"); // Godot loads the Resource when it reads the line.
		plant2 = (Texture)GD.Load("res://assets/plant2.png"); // Godot loads the Resource when it reads the line.

		Texture = plant1;
	}

	private Texture GetTexture(int time)
	{
		if (time < 2)
		{
			return plant1;
		} else 
		{
			return plant2;
		}
	}

	private void OnTimeUpdate()
	{
		time = (time + 1) % 2;
		EmitSignal("UpdateTime", time);
		Texture = GetTexture(time);
	}
}

