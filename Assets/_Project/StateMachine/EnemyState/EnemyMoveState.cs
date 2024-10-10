using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : MonoBehaviour, IState
{
    [SerializeField] float MoveSpeed;
    [SerializeField] Transform Target;
    public void OnStateEntered()
    {
        //Init stuff
    }

    public void OnStateExecute()
    {
        if(Target == null)
        {
            Debug.LogError($"No target assigned to {Target.gameObject.name}");
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, 
            Target.position, MoveSpeed * Time.deltaTime);
    }

    public void OnStateExit()
    {
        //On Exit stuff
    }
}
