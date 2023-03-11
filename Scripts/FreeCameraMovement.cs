using Godot;

public partial class FreeCameraMovement : Node3D
{
    private const float Speed = 10f;

    public override void _Process(double delta)
    {
        Move(delta);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            var x = mouseMotion.Relative.X;
            var y = mouseMotion.Relative.Y;

            RotateY(Mathf.Deg2Rad(-x));
            RotateX(Mathf.Deg2Rad(-y));
        }
    }

    private void Move(double delta)
    {
        var inputVector = GetInputVector();
        Translate(inputVector * (float)delta * Speed);
    }

    private Vector3 GetInputVector()
    {
        var direction = Vector3.Zero;
        var basis = GlobalTransform.Basis;
        var z = basis.Z;
        var x = basis.X;

        if (Input.IsActionPressed("camera_forward")) direction -= z;
        if (Input.IsActionPressed("camera_back")) direction += z;
        if (Input.IsActionPressed("camera_right")) direction += x;
        if (Input.IsActionPressed("camera_left")) direction -= x;

        return direction.Normalized();
    }
}
