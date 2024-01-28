using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace TTLibs.State
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        public void Initialize(IState state)
        {
            CurrentState = state;
            state.Enter();
        }

        public void ChangeState(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}
