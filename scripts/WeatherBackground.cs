
using Godot;
using System;

public class WeatherBackground : Sprite
{
	private int time = 0;
	private int effectCount = 0;
	
	private Texture sunnyB;
	private Texture cloudyB;
	private Texture rainyB;
	private Texture nightB;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		sunnyB = (Texture)GD.Load("res://assets/weather/Back_Sunny.png"); // Godot loads the Resource when it reads the line.
		cloudyB = (Texture)GD.Load("res://assets/weather/Back_Cloudy.png"); // Godot loads the Resource when it reads the line.
		rainyB = (Texture)GD.Load("res://assets/weather/Back_Rainy.png"); // Godot loads the Resource when it reads the line.	
		nightB = (Texture)GD.Load("res://assets/weather/Back_Night.png"); // Godot loads the Resource when it reads the line.	

		Texture = sunnyB;
	}

	private Texture GetTexture(int time)
	{
		if (time < 6) {
			return nightB;
		} else if (time > 22){
			return nightB;
		} else {	
			effectCount++;
			if (effectCount % 50 == 1) {
				return rainyB;
			} else if (effectCount %30 == 1) {
				return cloudyB;
			} else {
				return sunnyB;
			}
		}
	}


	public void UpdateTime(int hour)
		{
			Texture = GetTexture(hour);
	}
}

