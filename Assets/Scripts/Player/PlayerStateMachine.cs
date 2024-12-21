using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;  //创建一个state数组
    PlayerInput input;

    PlayerController player;

    Animator anim;

    private void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        anim = GetComponentInChildren<Animator>();

        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerController>();

        foreach (PlayerState state in states)  //为state字典填充state
        {
            state.Initialize(anim, input, player, this);
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        OnSwitchState(stateTable[typeof(Player_IdleState)]);
    }
}
