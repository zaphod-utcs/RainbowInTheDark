using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    Dictionary<string, IState> mStates = new Dictionary<string, IState>();
    IState mCurrentState = new EmptyState();
 	
	public IState CurrentState {
		get { return mCurrentState;}
	}
    public void Update()
    {
		//Debug.Log ("StateMachine::Update() mCurrentState: " + mCurrentState);
        mCurrentState.Update();
    }
 
    public void Render()
    {
        mCurrentState.Render();
    }
 
    public void ChangeState(string stateName, params object[] optParams)
    {
		//Debug.Log ("StateMachine::ChangeState() to " + stateName);
        mCurrentState.OnExit();
        mCurrentState = mStates[stateName];
		//Debug.Log ("StateMachine::ChangeState() mCurrentState: " + mCurrentState);
        mCurrentState.OnEnter(optParams);
		
		/* invoke: DoSomething(this, that, theOther);
		foreach(object o in optParams)
		  {
		    // Something with the Objects…
		  }
		*/
    }
 
    public void Add(string name, IState state)
    {
        mStates[name] = state;
    }
}
