using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<CharacterState>
{
    [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [field: SerializeField] public float PlayerInputX { get; private set; }
    [field: SerializeField] public float PlayerInputY { get; private set; }

    protected override void Start()
    {
        foreach (CharacterState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();
    }

    protected override void Update()
    {
        base.Update();
        PlayerInputX = Input.GetAxis("Horizontal");
        PlayerInputY = Input.GetAxis("Vertical");
    }

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new IdleState());
        m_possibleStates.Add(new MovingState());
        m_possibleStates.Add(new InAirState());
        m_possibleStates.Add(new GlidingState());
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
