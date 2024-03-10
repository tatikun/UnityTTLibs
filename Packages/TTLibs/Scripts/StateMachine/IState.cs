using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TTLibs.State
{
    public interface IState
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
    }
}