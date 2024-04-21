using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStateMachine : BaseStateMachine<MeleeEnemyState>
{
    [field:SerializeField] public Vector2 StartingPosition { get; private set; }
    [field:SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    protected override void Awake()
    {
        CreatePossibleStates();
    }
    protected override void Start()
    {
        foreach (MeleeEnemyState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        StartingPosition = this.transform.position;
    }
    protected override void CreatePossibleStates()
    {
        base.CreatePossibleStates();
        m_possibleStates = new List<MeleeEnemyState>();
        m_possibleStates.Add(new ScoutingState());
    }
}
