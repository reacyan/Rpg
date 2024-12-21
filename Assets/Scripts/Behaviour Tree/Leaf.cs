using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    readonly IStrategy strategy;

    public Leaf(string name, IStrategy strategy) : base(name)
    {
        this.strategy = strategy;
    }

    public override Status Process() => strategy.Process();

    public override void Reset()
    {
        strategy.Reset();
    }
}
