using Godot;
using System.Linq;

public partial class World : Node2D
{
    private Camera2D _camera;
    private Node2D _follow;
    private Node2D _resetPos;

    public override void _Ready()
    {
        _camera = GetNode<Camera2D>("Camera2D");
        _follow = GetNode<Node2D>("Player");
        _resetPos = GetNode<Node2D>("ResetPos");

        GetNode<Node>("Out").GetChildren().OfType<Area2D>().ToList().ForEach(ob =>
            ob.BodyEntered += OnBodyEntered
        );
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_follow == null)
            return;

        _camera.Position = new Vector2(_camera.Position.X, _follow.Position.Y);
    }

    private void OnBodyEntered(Node body)
    {
        if (body is PlayerController player)
        {
            player.Position = _resetPos.Position;
        }
    }
}
