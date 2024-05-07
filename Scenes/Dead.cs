using Godot;
using System;

public partial class Dead : Control
{
	// PackedScene titleScene;
	static string titleScreenPackedScenePath = "res://Scenes/TitleScene.tscn";

	public readonly PackedScene titleScene = ResourceLoader.Load<PackedScene>(titleScreenPackedScenePath);

	Timer deadDeadTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//titleScene = (PackedScene)GD.Load(titleScreenPackedScenePath);
		GD.Print(titleScreenPackedScenePath);
		deadDeadTimer = GetNode<Timer>("Dead Dead Timer");
		GD.Print(deadDeadTimer);
		GD.Print(deadDeadTimer.GetParent());
		deadDeadTimer.OneShot = true;
		deadDeadTimer.Timeout += onDeadDeadTimerTimeout;
		deadDeadTimer.Start();
	}

	public void onDeadDeadTimerTimeout() {
		GetTree().ChangeSceneToPacked(titleScene);
	}
}
