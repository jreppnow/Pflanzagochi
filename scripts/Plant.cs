using Godot;
using System;
using System.Collections.Generic;

public class Plant : AnimatedSprite
{
	private const String EMPTY_POT = "nothing";
	private const String GROWING = "growing";
	private const String GROWING_MIDDLE  = "middle_grown";
	private const String HAPPY = "happy";

	private readonly List<Vector2> dockablePositions = new List<Vector2>();

	[Export]
	public int happinessThreshold = 1000;
	[Export]
	public int waterDrainPerTick = 10;
	[Export]
	public int growingTime = 50;

	private int waterLevel = 0;
	private int happyTime = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("[PLANT] Spawning with hapinessThreshold " + happinessThreshold + " and growingTime " + growingTime + "!");
		Animation = EMPTY_POT;
		Show();
		dockablePositions.Add(new Vector2(240, 500));
	}

	public override void _Process(float delta)
	{
	}

	public void OnHappinessTimer()
	{
		GD.Print("[PLANT] Updating happiness!");
		drain();
		if (waterLevel >= happinessThreshold)
		{
			GD.Print("Increasing happiness to ", happyTime, " / " + growingTime + " ticks.");
			happyTime++;
		} else
		{
			happyTime = 0;
		}
		if (happyTime >= growingTime)
		{
			grow();
			happyTime = 0;
		}
	}

	private void grow()
	{
		Vector2 position = dockablePositions.GetEnumerator().Current;
		if (null != position)
		{
			Random random = new Random();
			Stalk stalk = GD.Load<PackedScene>("res://scenes/Stalk.tscn").Instance() as Stalk;
			AddChild(stalk);
			stalk.Rotation = random.Next(0, 20) - 10;
			stalk.Position = stalk.ComputeLocation(position);
			dockablePositions.Remove(position);
			dockablePositions.Add(stalk.ComputeNextLocation());
		}
	}

	private void drain()
	{
		if (waterLevel < waterDrainPerTick)
		{
			waterLevel = 0;
		} else
		{
			waterLevel -= waterDrainPerTick;
		}
		GD.Print("[PLANT] Drained water. New water level: ", waterLevel);
	}
}

