using Godot;
using System;

public class WeatherEffect : Sprite
{
	private int time = 0;
	private Texture sunny;
	private Texture cloudy;
	private Texture rainy;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sunny = (Texture)GD.Load("res://assets/weather/weather_sunny.png"); // Godot loads the Resource when it reads the line.
		cloudy = (Texture)GD.Load("res://assets/weather/weather_cloudy.png"); // Godot loads the Resource when it reads the line.
		rainy = (Texture)GD.Load("res://assets/weather/weather_rainy.png"); // Godot loads the Resource when it reads the line.

		Texture = sunny;
	}

	private Texture GetTexture(int time)
	{
		if (time == 0)
		{
			return rainy;
		}
		else if (time == 1)
		{
			return cloudy;
		}
		else
		{
			return sunny;
		}
	}


	public void UpdateTime(int hour)
		{
			Texture = GetTexture(hour % 3);
		// Replace with function body.
	}
}
