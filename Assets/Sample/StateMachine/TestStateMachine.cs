using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TTLibs;
using TTLibs.State;

class HogeState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Hoge");
    }

    public void Exit()
    {
        Debug.Log("Exit Hoge");
    }

    public void Update()
    {
    }
}
class FugaState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Hoge");
    }

    public void Exit()
    {
        Debug.Log("Exit Fuga");
    }

    public void Update()
    {
        Debug.Log("Fuga");
    }
}

public class TestStateMachine : MonoBehaviour
{
    StateMachine testStateMachine;
    HogeState hogeState;
    FugaState fugaState;

    int count = 0;
    int MAXCOUNT = 100;
    private void Start()
    {
        testStateMachine = new StateMachine();
        hogeState = new HogeState();
        fugaState = new FugaState();
        testStateMachine.Initialize(hogeState);
    }

    private void Update()
    {
        count++;
        if(count > MAXCOUNT)
        {
            testStateMachine.Update();
            count = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(testStateMachine.CurrentState is HogeState)
            {
                testStateMachine.ChangeState(fugaState);
            }
            else
            {
                testStateMachine.ChangeState(hogeState);
            }
        }
    }

}
