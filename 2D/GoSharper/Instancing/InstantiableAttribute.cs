using System;

namespace toybox.GoSharper.Instancing;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InstantiableAttribute : Attribute
{
  public InstantiableAttribute(string path)
  {
    Path = path;
  }

  public string Path { get; }
}
