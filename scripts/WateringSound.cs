using Godot;
using System;

public class WateringSound : AudioStreamPlayer2D
{
	
	public void Pouring(Vector2 location)
	{
		Play();
	}
}
