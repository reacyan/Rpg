using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenState : ScriptableObject, IState
{

    protected float stateTimer;
    protected bool triggerBack;

    protected Animator anim;
    protected ChickenController chicken;
    protected ChickenStateMachine stateMachine;

    public void Initialize(Animator _anim, ChickenController _chicken, ChickenStateMachine _stateMachine)  //初始化state
    {
        this.anim = _anim;
        this.chicken = _chicken;
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {
        triggerBack = false;
    }

    public virtual void Exit()
    {
        triggerBack = true;
    }

    public virtual void LogicUpdate()
    {
        stateTimer -= Time.deltaTime;

    }

    public virtual void PhysicsUpdate()
    {
    }
}
