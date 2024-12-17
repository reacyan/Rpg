using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

    protected Dictionary<System.Type, IState> stateTable;

    // public StateMachine()
    // {
    //     this.stateTable = new Dictionary<System.Type, IState>();
    // }

    public void OnSwitchState(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void inSwitchState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        OnSwitchState(newState);
    }

    public void SwitchState(System.Type newStateType)
    {
        inSwitchState(stateTable[newStateType]);
    }

    private void Update()
    {
        currentState.LogicUpdate();
    }
}
