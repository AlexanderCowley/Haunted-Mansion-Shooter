using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNode : MonoBehaviour
{
    [field:SerializeField] public EnemyNode NextNode{get; private set;}

    [field:SerializeField] public float MoveSpeed {get; private set;}
    [field:SerializeField] public float RotationSpeed {get; private set;}
    [SerializeField] string AnimStateName;
    [SerializeField] AnimationClip AnimClip;

    public delegate void OnNodeEntered();
    public event OnNodeEntered NodeEnteredHandler;

    void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.SetNode(this);
            enemy.PlayAnimation(AnimStateName);
        }
        //NodeEnteredHandler?.Invoke();
    }
}
