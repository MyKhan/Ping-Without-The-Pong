using Godot;
using System;
using System.Reflection;

public partial class Score : Label
{
	int healthLeft;
	string healthRemaining;

	Color red = new Color(255, 0, 0);
	Color green = new Color(0, 255, 0);
	Color white = new Color(255, 255, 255);

	public override void _Ready()
	{
		healthLeft = Globals.health;
		Modulate = green;
		healthRemaining = "Player Health Left: " + healthLeft;
	}

	public override void _Process(double delta)
	{
		healthLeft = Globals.health;
		healthRemaining = "Player Health Left: " + healthLeft;
		Text = healthRemaining;

		if (healthLeft == 2) {
			Modulate = white;
		} else if (healthLeft <= 1) {
			Modulate = red;
		}
	}
}
