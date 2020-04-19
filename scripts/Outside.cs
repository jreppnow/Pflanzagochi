using Godot;
using System;

public class Outside : Sprite
{
	private static int NIGHT = 0;
	private static int SUNNY = 1;
	private static int RAINY = 2;
	private static int CLOUDY = 3;
	
	private static int weatherCondition = SUNNY;
	private int effectCount = 0;
	
	
	[Signal]
	public delegate void UpdateWeather(int weather);
	
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

	private void GenerateWeatherConditions(int time)
	{
		if (time < 6 || time > 22){	
			weatherCondition = NIGHT;
			Texture = night;
		} else {	
			GenerateDayTimeWeather();
		}
		EmitSignal("UpdateWeather", weatherCondition);
	}
	
	private void GenerateDayTimeWeather() {
		effectCount++;		
		if (effectCount < 2) {
			weatherCondition = CLOUDY;
			Texture = cloudy;
		} else if (effectCount < 5) {
			weatherCondition = RAINY;
			Texture = rainy;
		} else if (effectCount < 8) {
			weatherCondition = CLOUDY;
			Texture = cloudy;
		} else if (effectCount > 20) {
			effectCount = 0;
		} else {
			weatherCondition = SUNNY;
			Texture = sunny;
		}
		
	}
	
	private Texture GetWeatherTexture() {
		if(weatherCondition == NIGHT ) {	
			return night;
		} else if (weatherCondition == RAINY ) {
			return rainy;
		} else if ( weatherCondition == CLOUDY) {
			return cloudy;
		} else {
			return sunny;
		}
	}

	public void UpdateTime(int hour)
	{
		GenerateWeatherConditions(hour);
	}
}
