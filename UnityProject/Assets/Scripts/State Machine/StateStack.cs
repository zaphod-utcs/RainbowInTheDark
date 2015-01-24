using System.Collections;
using System.Collections.Generic;

public class StateStack
{
    Dictionary<string, IState> mStates = new Dictionary<string, IState>();
    //List<IState> mStack = new List<IState>();
	Stack<IState> mStack = new Stack<IState>();
 
    public void Update()
    {
        IState top = mStack.Peek();
        top.Update();
    }
 
    public void Render()
    {
        IState top = mStack.Peek();
        top.Render();
    }
 
    public void Push(string name)
    {
        IState state = mStates[name];
        mStack.Push(state);
    }
 
    public IState Pop()
    {
		if (mStack.Count > 0)
        	return mStack.Pop();
		else return null;
    }
}