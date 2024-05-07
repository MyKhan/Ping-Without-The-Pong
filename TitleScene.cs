using Godot;
using System;
using System.Runtime.Serialization;

public partial class TitleScene : Control
{
	Button startButton;

	[Export]
	PackedScene mainScene;

	Button quitButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startButton = GetNode<Button>("Start");
		quitButton = GetNode<Button>("Quit");
		startButton.Pressed += onStartButtonPressed;
		quitButton.Pressed += onQuitButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void onStartButtonPressed(){
		GetTree().ChangeSceneToPacked(mainScene);
	}

	public void onQuitButtonPressed(){
		GetTree().Quit();
	}
}
