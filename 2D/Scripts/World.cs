using Godot;
using GodotSharper;
using GodotSharper.AutoGetNode;

namespace toybox.Scripts;

public partial class World : Node2D
{
    [GetNode("Spawner")]
    private Spawner _spawner;

    [GetNode("Void")]
    private Area2D _void;

    public override void _Ready()
    {
        this.GetNodes();
        _spawner.BallSpawned += OnBallSpawned;
        _void.BodyEntered += OnVoidBodyEntered;

        AddChild(TimerFactory.StartedOneShot(10, () => GD.Print("Hello World!")));
    }

    private static void OnVoidBodyEntered(Node2D body)
    {
        if (body is Ball ball)
            ball.QueueFree();
    }

    private void OnBallSpawned(Node2D ball, Vector2 globalPosition)
    {
        // NOTE: AddChild() must be called before setting the GlobalPosition.
        AddChild(ball);
        ball.GlobalPosition = globalPosition;
    }
}
