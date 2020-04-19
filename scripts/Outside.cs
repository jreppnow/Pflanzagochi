using Godot;
using System;

public class Outside : Sprite
{
	private int effectCount = 0;
	
	private Texture sunny;
	private Texture cloudy;
	private Texture rainy;
	private Texture night;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		sunny = (Texture)GD.Load("res://assets/weather/Back_Sunny.png"); // Godot loads the Resource when it reads the line.
		cloudy = (Texture)GD.Load("res://assets/weather/Back_Cloudy.png"); // Godot loads the Resource when it reads the line.
		rainy = (Texture)GD.Load("res://assets/weather/Back_Rainy.png"); // Godot loads the Resource when it reads the line.	
		night = (Texture)GD.Load("res://assets/weather/Back_Night.png"); // Godot loads the Resource when it reads the line.	

		Texture = sunny;
	}

	private Texture GetTexture(int time)
	{
		if (time < 6 || time > 22){
			return night;
		} else {	
			return GenerateDayTimeWeather();
		}
	}
	
	private Texture GenerateDayTimeWeather() {
		effectCount++;
			if (effectCount % 50 == 1) {
				return rainy;
			} else if (effectCount %30 == 1) {
				return cloudy;
			} else {
				return sunny;
			}
	}


	public void UpdateTime(int hour)
	{
			Texture = GetTexture(hour);
	}
}
