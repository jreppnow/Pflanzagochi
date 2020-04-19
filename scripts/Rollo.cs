using Godot;
using System;

public class Rollo : Sprite
{
	[Signal]
	public delegate void UpdateRolloState();
	
	private static int NIGHT = 0;
	private static int SUNNY = 1;
	private static int RAINY = 2;
	private static int CLOUDY = 3;
	
	
	private Texture open;
	private Texture half;
	private Texture close;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		open = (Texture)GD.Load("res://assets/rollo/rollo_open.png"); // Godot loads the Resource when it reads the line.
		half = (Texture)GD.Load("res://assets/rollo/rollo_half.png"); // Godot loads the Resource when it reads the line.
		close = (Texture)GD.Load("res://assets/rollo/rollo_close.png"); // Godot loads the Resource when it reads the line.	

		Texture = open;
	}
	
	public void UpdateWeather(int weather)
	{
		Texture old = Texture;
		if(weather == NIGHT) {
			Texture = open;
		} else if(weather == RAINY ){
			Texture = half;
		} else {
			Texture = close;
		}
		
		if(old != Texture) {
			EmitSignal("UpdateRolloState");
		} 
	}
}
