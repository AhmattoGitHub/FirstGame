using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<CharacterState>
{
    [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [field: SerializeField] public float PlayerInputX { get; private set; }
    [field: SerializeField] public float PlayerInputY { get; private set; }
    [field: SerializeField] public bool IsInAir { get; private set; } = false;
    [field: SerializeField] public bool IsWalking { get; private set; } = false;
    [field: SerializeField] public int MaxSpeed { get; private set; } = 10;
    [field: SerializeField] public int AccelerationValue { get; private set; } = 3;

    private const int NUMBER_OF_JUMPS = 2;
    private int m_jumpCount = 0;

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
        CheckForWASDInput();
        CheckForJumpInput();
    }

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new IdleState());
        m_possibleStates.Add(new WalkingState());
        m_possibleStates.Add(new InAirState());
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void CheckForWASDInput()
    {
        PlayerInputX = Input.GetAxis("Horizontal");
        PlayerInputY = Input.GetAxis("Vertical");
        if(PlayerInputX != 0)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }
    }

    private void CheckForJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if(m_jumpCount < NUMBER_OF_JUMPS)
            {
                m_jumpCount++;
                RigidBody.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            IsInAir = false;
            m_jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsInAir = true;
        }
    }
}
