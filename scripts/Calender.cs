using Godot;
using System;

public class Calender : Node
{
	private int currentDay = 0;
	
	public void UpdateDay(int day)
	{
		if(currentDay != day) {
			Day dayLabel = GetNode("Day") as Day;
			dayLabel.UpdateDay(day);
			currentDay = day;
		}

	}
}
