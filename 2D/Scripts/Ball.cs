using Godot;
using GodotSharper.Instancing;
using toybox.Scripts.Utils;

namespace toybox.Scripts;

[Instantiable(ObjectResources.BallScene)]
public partial class Ball : RigidBody2D { }
