using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : AbstractStateMachine
{
    void OnEnable() 
    {
        ChangeState<EnemyIdleState>();
    }
}
