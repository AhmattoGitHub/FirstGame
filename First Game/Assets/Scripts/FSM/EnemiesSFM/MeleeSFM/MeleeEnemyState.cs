using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyState : IState
{
    protected MeleeEnemyStateMachine m_meleeEnemyStateMachine;

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

    }

    public virtual void OnExit()
    {

    }

    public virtual void OnFixedUpdate()
    {

    }

    public virtual void OnStart(MeleeEnemyStateMachine meleeEnemyStateMachine)
    {
        m_meleeEnemyStateMachine = meleeEnemyStateMachine;
    }

    public void OnStart()
    {

    }
    public virtual void OnUpdate()
    {

    }
}
