using Godot;

public partial class PlayerController : Node3D
{
    public override void _Ready()
    {
        GD.Print("Hello World!");
    }

    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.W))
        {
            GD.Print("W is pressed");
        }
    }

    private Vector3 GetInputVector()
    {
        var direction = Vector3.Zero;
        var basis = GlobalTransform.Basis;
        var z = basis.Z;
        var x = basis.X;

        if (Input.IsActionPressed("forward")) direction -= z;
        if (Input.IsActionPressed("back")) direction += z;
        if (Input.IsActionPressed("right")) direction += x;
        if (Input.IsActionPressed("left")) direction -= x;

        return direction.Normalized();
    }
}
