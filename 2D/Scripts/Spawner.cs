using Godot;

namespace toybox.Scripts;

public partial class Spawner : Node2D
{
    [Signal]
    public delegate void BallSpawnedEventHandler(Node2D ball, Vector2 globalPosition);

    private readonly PackedScene BallScene = GD.Load<PackedScene>("res://Objects/Ball.tscn");

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("spawn_ball"))
            SpawnBallAtMouse();
    }

    private void SpawnBallAtMouse()
    {
        var ball = BallScene.Instantiate();
        var mousePos = GetGlobalMousePosition();
        EmitSignal(SignalName.BallSpawned, ball, mousePos);
    }
}
