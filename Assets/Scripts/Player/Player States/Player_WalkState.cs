using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Walk", fileName = "PlayerState_Walk")]

public class Player_WalkState : PlayerState
{
    public override void Enter()
    {
        anim.Play("Walk");
    }

    public override void LogicUpdate()
    {
        anim.SetFloat("MoveX", input.currentAxes.x);
        anim.SetFloat("MoveY", input.currentAxes.y);

        player.SetVelocity(player.inputDirection.x * player.walkSpeed, player.inputDirection.y * player.walkSpeed);

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
        player.SetZeroVelocity();
    }
}
