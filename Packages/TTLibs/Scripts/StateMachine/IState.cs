using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TTLibs.State
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Update();
    }
}