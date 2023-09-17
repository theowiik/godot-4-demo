using Godot;
using GodotSharper.Instancing;

namespace toybox.Scripts;

public partial class Spawner : Node2D
{
    [Signal]
    public delegate void BallSpawnedEventHandler(Node2D ball, Vector2 globalPosition);

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("spawn_ball"))
            SpawnBallAtMouse();
    }

    private void SpawnBallAtMouse()
    {
        var ball = Instanter.Instantiate<Ball>();
        var mousePos = GetGlobalMousePosition();
        EmitSignal(SignalName.BallSpawned, ball, mousePos);
    }
}
