using Godot;
using GodotSharper.AutoGetNode;

namespace toybox.Scripts;

public partial class World : Node2D
{
    [GetNode("Spawner")]
    private Spawner _spawner;

    public override void _Ready()
    {
        this.GetNodes();
        _spawner.BallSpawned += OnBallSpawned;
    }

    private void OnBallSpawned(Node2D ball, Vector2 globalPosition)
    {
        // NOTE: AddChild() must be called before setting the GlobalPosition.
        AddChild(ball);
        ball.GlobalPosition = globalPosition;
    }
}
