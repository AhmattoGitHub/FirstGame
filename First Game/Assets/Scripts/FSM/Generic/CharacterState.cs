
using UnityEngine;

public abstract class CharacterState : IState
{
    protected PlayerStateMachine playerStateMachine;
    public virtual bool CanEnter(IState currentState)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool CanExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnStart(PlayerStateMachine stateMachine)
    {
        playerStateMachine = stateMachine;
    }

    public void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
