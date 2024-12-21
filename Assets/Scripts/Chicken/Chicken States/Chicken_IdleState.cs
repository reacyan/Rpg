using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/ChickenState/Idle", fileName = "Chicken_Idle")]

public class Chicken_IdleState : ChickenState
{
    float idleTime = 2f;

    public override void Enter()
    {
        base.Enter();

        stateTimer = idleTime;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        anim.SetFloat("WalkX", chicken.EntityDirection.x);
        anim.SetFloat("WalkY", chicken.EntityDirection.y);

        if (stateTimer < 0)
        {
            stateMachine.SwitchState(typeof(Chicken_WalkState));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
