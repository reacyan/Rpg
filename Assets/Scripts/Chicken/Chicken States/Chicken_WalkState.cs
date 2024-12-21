using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/ChickenState/Walk", fileName = "Chicken_Walk")]

public class Chicken_WalkState : ChickenState
{
    float walkTime = 4f;

    public override void Enter()
    {
        base.Enter();

        stateTimer = walkTime;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        anim.SetFloat("WalkX", chicken.EntityDirection.x);
        anim.SetFloat("WalkY", chicken.EntityDirection.y);

        int xVelocity = Random.Range(-1, 2);
        int yVelocity = Random.Range(-1, 2);

        chicken.SetVelocity(xVelocity * chicken.walkSpeed, yVelocity * chicken.walkSpeed);

        if (stateTimer < 0)
        {
            stateMachine.SwitchState(typeof(Chicken_IdleState));
        }
    }

    public override void Exit()
    {
        base.Exit();

        chicken.SetZeroVelocity();
    }
}
