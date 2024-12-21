using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Walk", fileName = "PlayerState_Walk")]

public class Player_WalkState : PlayerState
{
    public override void Enter()
    {
        base.Enter();

        anim.Play("Walk");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        anim.SetFloat("MoveX", input.currentAxes.x);
        anim.SetFloat("MoveY", input.currentAxes.y);

        player.SetVelocity(input.currentAxes.x * player.walkSpeed, input.currentAxes.y * player.walkSpeed);

        if (!input.move)
        {
            stateMachine.SwitchState(typeof(Player_IdleState));
        }
        else if (input.Run)
        {
            stateMachine.SwitchState(typeof(Player_RunState));
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.SetZeroVelocity();
    }
}
