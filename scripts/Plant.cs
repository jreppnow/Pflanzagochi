using Godot;
using System;

public class Plant : AnimatedSprite
{
	[Signal]
	public delegate void UpdateGameOver();
	
	private const String DEAD = "dead";
	private const String SMALL  = "small";	
	private const String MEDIUM = "medium";
	private const String LARGE = "large";

	private int waterLevel = 190;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Animation = SMALL;
		Show();
	}
	
	private void checkHappiness() {
		if(waterLevel < 0 || waterLevel >1000) {
			Animation = DEAD;
			EmitSignal("UpdateGameOver");
		} else if(waterLevel > 400 && waterLevel < 600) {
			Animation = LARGE;
		} else if(waterLevel > 200 && waterLevel < 800) {
			Animation = MEDIUM;
		} else {
			Animation = SMALL;
		}
		
	}

	public void UpdateTime(int hour)
	{
		waterLevel = waterLevel -10;
		GD.Print("[PLANT] water level falling: ", waterLevel);
		checkHappiness();
	}

	public void Pouring(Vector2 location)
	{
		waterLevel++;
		GD.Print("[PLANT] water level rising: ", waterLevel);
		checkHappiness();
	}
}
