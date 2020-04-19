using Godot;
using System;

public class Calender : Node
{
	public void UpdateDay(int day)
	{
		Day dayLabel = GetNode("Day") as Day;
		dayLabel.UpdateDay(day);
	}
}
