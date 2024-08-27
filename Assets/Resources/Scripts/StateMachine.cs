using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }
    public void TransitionTo(IState nextState){
        if(CurrentState != null) CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }
    public void Update(){
        CurrentState.Update();
    }
}
