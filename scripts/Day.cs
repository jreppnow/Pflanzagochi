using Godot;
using System;

public class Day : Label
{

	
	public void UpdateDay(int day)
	{
		GD.Print("[Calender]: Today is day " + day + " of the calender");
	}

}
