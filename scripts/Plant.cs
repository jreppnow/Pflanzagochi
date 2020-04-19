using Godot;
using System;

public class Plant : AnimatedSprite
{
	private const String EMPTY_POT = "nothing";
	private const String DEAD = "growing";
	private const String DYING  = "middle_grown";
	private const String HAPPY = "happy";

	[Signal]
	public delegate void Died();

	[Export]
	public int waterLevelLowerThreshold = 1000;
	[Export]
	public int waterLevelHigherThreshold = 3000;
	[Export]
	public int drainingRate = 10;
	[Export]
	public int pouringRate = 100;
	[Export]
	public int growingTime = 50;
	[Export]
	public int dryOutTimeThreshold = 30000;
	[Export]
	public int overwateringTimeThreshold = 1000000;
	[Export]
	public int statusDropTimeThreshold = 100000;

	private int dryingOutTime = -1;
	private int overwateringTime = -1;

	private int waterLevel = 0;
	private int unhappyTime = 0;
	private int lastTickedTime = 0;
	private bool pouring = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Animation = HAPPY;
		Show();
	}

	public override void _Process(float delta)
	{
	}

	private void drain(int delta)
	{
		int draining = delta * drainingRate;
		if (waterLevel <= draining)
		{
			waterLevel = 0;
		} else
		{
			waterLevel -= draining;
		}
		GD.Print("[PLANT] Drained water. New water level: ", waterLevel);
	}

	private void UpdateState(int delta)
	{
		if (waterLevel < waterLevelLowerThreshold)
		{
			dryingOutTime = dryingOutTime == -1 ? delta : dryingOutTime + delta;
			overwateringTime = -1;
			unhappyTime += delta;
		} else if (waterLevel > waterLevelHigherThreshold)
		{
			overwateringTime = overwateringTime == -1 ? delta : overwateringTime + delta;
			dryingOutTime = -1;
			unhappyTime += delta;
		} else
		{
			unhappyTime = 0;
			overwateringTime = dryingOutTime = -1;
		}
		if (unhappyTime <= 0)
		{
			Animation = HAPPY;
		} else if (unhappyTime <= statusDropTimeThreshold)
		{
			Animation = DYING;
		} else
		{
			Animation = DEAD;
			EmitSignal("Died");
		}
	}

	private void UpdateGameTime(int time)
	{
		int passedTime = time - lastTickedTime;
		if (pouring)
		{
			pour(passedTime);
		} else
		{
			drain(passedTime);
		}
		UpdateState(passedTime);
	}

	private void pour(int delta)
	{
		waterLevel += delta * pouringRate;
	}
}


