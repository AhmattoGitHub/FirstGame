using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStateMachine : BaseStateMachine<EnemyState>
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void CreatePossibleStates()
    {
        base.CreatePossibleStates();
        m_possibleStates = new List<EnemyState>();
        m_possibleStates.Add(new ScoutingState());
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Update()
    {
        base.Update();
    }
}
