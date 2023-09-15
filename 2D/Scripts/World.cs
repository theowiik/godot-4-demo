using Godot;

namespace toybox.Scripts;

public partial class World : Node2D
{
    private Spawner _spawner;

    public override void _Ready()
    {
        _spawner = GetNode<Spawner>("Spawner");
        _spawner.BallSpawned += OnBallSpawned;
    }

    private void OnBallSpawned(Node2D ball, Vector2 globalPosition)
    {
        // NOTE: AddChild() must be called before setting the GlobalPosition.
        AddChild(ball);
        ball.GlobalPosition = globalPosition;
    }
}
