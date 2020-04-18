using Godot;
using System;

public class Plant : AnimatedSprite
{
	private const String EMPTY_POT = "nothing";
	private const String GROWING = "growing";
	private const String GROWING_MIDDLE  = "middle_grown";
	private const String HAPPY = "happy";

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
		if (Animation == EMPTY_POT)
		{
			Animation = GROWING;
		} else if (Animation == GROWING)
		{
			Animation = GROWING_MIDDLE;
		} else if (Animation == GROWING_MIDDLE)
		{
			Animation = HAPPY;
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

