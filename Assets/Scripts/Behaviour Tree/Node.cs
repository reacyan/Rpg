using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum Status { Success, Failure, Running }//Node状态

    public readonly string name;

    public readonly List<Node> children = new List<Node>();  //子节点

    protected int currentChild;

    public Node(string _name = "Node")
    {
        this.name = _name;
    }

    public void AddChildren(Node child) => children.Add(child);  //添加节点

    public virtual Status Process() => children[currentChild].Process();  //获取子节点运行状态

    public virtual void Reset()
    {
        currentChild = 0;
        foreach (var child in children)
        {
            child.Reset();
        }
    }
}
