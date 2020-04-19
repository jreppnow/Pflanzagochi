using Godot;
using System;

public class Clock : Sprite
{
	[Signal]
	public delegate void UpdateTime(int hour);
	[Signal]
	public delegate void UpdateDay(int day);	
	[Signal]
	public delegate void UpdateWakeUp();
	[Signal]
	public delegate void UpdateGameTime(int time);

	[Export]
	public int gameTimeVsRealTimeFactor = 100;

	private int time = 0; // current time in seconds
	
	private Texture[] clock = new Texture[12];
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		clock[0] = (Texture) GD.Load("res://assets/clock/Time_1.png"); // Godot loads the Resource when it reads the line.
		clock[1] = (Texture) GD.Load("res://assets/clock/Time_2.png"); // Godot loads the Resource when it reads the line.
		clock[2] = (Texture) GD.Load("res://assets/clock/Time_3.png"); // Godot loads the Resource when it reads the line.
		clock[3] = (Texture) GD.Load("res://assets/clock/Time_4.png"); // Godot loads the Resource when it reads the line.
		clock[4] = (Texture) GD.Load("res://assets/clock/Time_5.png"); // Godot loads the Resource when it reads the line.
		clock[5] = (Texture) GD.Load("res://assets/clock/Time_6.png"); // Godot loads the Resource when it reads the line.
		clock[6] = (Texture) GD.Load("res://assets/clock/Time_7.png"); // Godot loads the Resource when it reads the line.
		clock[7] = (Texture) GD.Load("res://assets/clock/Time_8.png"); // Godot loads the Resource when it reads the line.
		clock[8] = (Texture) GD.Load("res://assets/clock/Time_9.png"); // Godot loads the Resource when it reads the line.
		clock[9] = (Texture) GD.Load("res://assets/clock/Time_10.png"); // Godot loads the Resource when it reads the line.
		clock[10] = (Texture) GD.Load("res://assets/clock/Time_11.png"); // Godot loads the Resource when it reads the line.
		clock[11] = (Texture) GD.Load("res://assets/clock/Time_12.png"); // Godot loads the Resource when it reads the line.

		Texture = clock[0];
	}

	private void OnTimeUpdate()
	{
		time += gameTimeVsRealTimeFactor;
		EmitSignal("UpdateGameTime", time);
		updateHours((time / (60 * 60)) % 24);
		updateDays(time / (60 * 60 * 24));
	}
	
	private void updateHours(int hours) {
		EmitSignal("UpdateTime", hours);
		if (hours == 6) {
			EmitSignal("UpdateWakeUp");
		}
		
		GD.Print("[CLOCK]: Update time to ", hours, " o'clock..");
		Texture = clock[hours % 12];
	}
	
	private void updateDays(int days) {
		EmitSignal("UpdateDay", days );
	}
}
