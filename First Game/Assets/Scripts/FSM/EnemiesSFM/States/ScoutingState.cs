using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ScoutingState : EnemyState
{
    public override bool CanEnter(IState currentState)
    {
        return true;
    }

    public override bool CanExit()
    {
        return false;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Scouting State!");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Scouting State!");
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }
}
