using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Circle,
    Triangle,
    Square,
    Hexagon,
}

public interface ICollectable
{
    Type Type { get; }
    void Move();
    void Collect();
}

