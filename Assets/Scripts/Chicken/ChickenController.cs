using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : Entity
{
    BehaviourTree tree;
    PlayerController player;


    protected override void Awake()
    {
        base.Awake();

        player = PlayerManager.instance.player;

        tree = new BehaviourTree("Chicken");
        tree.AddChildren(new Leaf("Follow", new Follow_Strategy(player.transform, this.transform, true)));
    }

    protected override void Update()
    {
        base.Update();

        tree.Process();
    }

    public override void SetVelocity(float _xVelocity, float _yVelocity)
    {
        base.SetVelocity(_xVelocity, _yVelocity);

        EntityDirection = new Vector3(_xVelocity, _yVelocity, 0).normalized;
    }

}
