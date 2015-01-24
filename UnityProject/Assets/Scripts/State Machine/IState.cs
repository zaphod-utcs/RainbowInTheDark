using UnityEngine;

public interface IState
{
    void Update();
    void Render();
    void OnEnter(params object[] optParams);
    void OnExit();
}
public class EmptyState : IState
{
    public void Update()
    {
    }
    public void Render()
    {
    }
    public void OnEnter(params object[] optParams)
    {
    }
    public void OnExit()
    {
    }
}
