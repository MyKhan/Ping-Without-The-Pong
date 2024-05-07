using Godot;
using Godot.Collections;
using System;

public partial class Level : Node2D
{
    Timer restartTimer;
    Timer deadTimer;

    Array<Node> spawnPositions = null;

    Marker2D spawnPosition;

    [Export]
    PackedScene zeBall;

    [Export]
    PackedScene deadScene;

    public Area2D playArea;

    public override void _Ready()
    {
        base._Ready();

        spawnPositions = GetNodeOrNull<Node>("SpawnPositions").GetChildren();

        updateSpawnPosition();
        
        spawnANewZeBall();

        restartTimer = GetNode<Timer>("Restart Timer");
        restartTimer.Timeout += onRestartTimerTimeout;

        playArea = GetNode<Area2D>("Play Area");
        playArea.BodyExited += onPlayAreaBodyExited;

        deadTimer = GetNode<Timer>("Dead Timer");
        deadTimer.Timeout += onDeadTimerTimeout;
    }


    public override void _Process(double delta){
    }

    public void updateSpawnPosition() {
        int i = GD.RandRange(0, 2);
        spawnPosition = (Marker2D)spawnPositions[i];
    }

    private void onPlayAreaBodyExited (Node2D body) {
        deleteZeBall(body);
        if (Globals.health > 0) {
            restartTimer.Start();
        }
        if (Globals.health == 0) {
            deadTimer.Start();
        }
	}


    public void onRestartTimerTimeout () {
        updateSpawnPosition();
        Globals.health--;
        spawnANewZeBall();
	}

    public void spawnANewZeBall() {
        RigidBody2D newBallScene = (RigidBody2D)zeBall.Instantiate();
        newBallScene.Position = spawnPosition.GlobalPosition;
        newBallScene.LinearVelocity = new Vector2(1500, newBallScene.LinearVelocity.Y);
        AddChild(newBallScene);
    }

    public void deleteZeBall(Node2D ball) {
        ball.QueueFree();
    }

    public void onDeadTimerTimeout() {
        GetTree().ChangeSceneToPacked(deadScene);
    }

}
