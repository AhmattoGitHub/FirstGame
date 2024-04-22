using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStateMachine : BaseStateMachine<MeleeEnemyState>
{
    [field:SerializeField] public Vector2 StartingPosition { get; private set; }
    [field:SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field:SerializeField] public bool ChasingPlayer { get; private set; }

    private GameObject m_player;
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
        m_player = TestLevelManager.Instance.GetPlayer();
    }
    protected override void CreatePossibleStates()
    {
        base.CreatePossibleStates();
        m_possibleStates = new List<MeleeEnemyState>();
        m_possibleStates.Add(new ScoutingState());
        m_possibleStates.Add(new ChasingState());
    }

    protected override void Update()
    {
        base.Update();
        CheckIfPlayerIsClose();
    }

    private void CheckIfPlayerIsClose()
    {
        if(m_player != null)
        {
            if(Mathf.Abs(m_player.transform.position.x - this.transform.position.x) <=3 )
            {
                ChasingPlayer = true;
            }
        }
    }
}
