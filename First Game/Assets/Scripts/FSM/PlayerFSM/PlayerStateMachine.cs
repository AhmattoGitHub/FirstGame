using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<CharacterState>
{
    [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [field: SerializeField] public float PlayerInputX { get; private set; }
    [field: SerializeField] public float PlayerInputY { get; private set; }
    [field: SerializeField] public bool IsInAir { get; private set; } = false;
    [field: SerializeField] public bool IsWalking { get; private set; } = false;
    [field: SerializeField] public int SpeedValue { get; private set; } = 10;

    private const int NUMBER_OF_JUMPS = 2;
    private int m_jumpCount = 0;
    private const int JUMP_FORCE = 10;

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
        UpdateGravityScale();
    }

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new IdleState());
        m_possibleStates.Add(new WalkingState());
        m_possibleStates.Add(new InAirState());
        m_possibleStates.Add(new ZeroGravityState());
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
        if(Input.GetKeyDown(KeyCode.Space) && RigidBody.gravityScale != 0) 
        {
            if(m_jumpCount < NUMBER_OF_JUMPS)
            {
                m_jumpCount++;
                RigidBody.AddForce(Vector2.up * (JUMP_FORCE + (RigidBody.velocity.y * -1)),ForceMode2D.Impulse);
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

    private void UpdateGravityScale()
    {
        RigidBody.gravityScale = TestLevelManager.Instance.GetLevelGravityScale();
    }
}
