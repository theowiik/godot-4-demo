using Godot;

public partial class PlayerController : CharacterBody2D
{
    private const float Speed = 300.0f;
    private const float JumpVelocity = -400.0f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _PhysicsProcess(double delta)
    {
        MyMovement(delta);
    }

    private void MyMovement(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += gravity * (float)delta;
            Velocity = velocity;
        }

        if (Input.IsActionJustPressed("ui_right") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
            velocity.X = JumpVelocity;
            GD.Print("Jump Right");
        }

        if (Input.IsActionJustPressed("ui_left") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
            velocity.X = -JumpVelocity;
            GD.Print("Jump Left");
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void TemplateMovement(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y += gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
            velocity.Y = JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
