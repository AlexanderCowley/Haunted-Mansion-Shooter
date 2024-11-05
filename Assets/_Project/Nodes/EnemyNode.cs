using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyNode : MonoBehaviour
{
    [field:SerializeField] public EnemyNode NextNode{get; private set;}

    [field:SerializeField] public float MoveSpeed {get; private set;}
    [field:SerializeField] public float RotationSpeed {get; private set;}
    [SerializeField] string AnimStateName;
    [field:SerializeField] public bool IsAttack {get; private set;} = false;

    void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.SetNode(this);
            enemy.PlayAnimation(AnimStateName);
        }
        //NodeEnteredHandler?.Invoke();
    }

    #if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.8f);
        if(NextNode != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, NextNode.transform.position);
        }
    }
    #endif
}
