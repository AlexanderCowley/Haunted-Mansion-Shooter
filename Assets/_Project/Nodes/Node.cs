using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    [field:SerializeField] public Node NextNode{get; private set;}
    [field:SerializeField] public bool ActiveInput{get; private set;} = true;

    [field:SerializeField] public float MoveSpeed {get; private set;}
    [field:SerializeField] public float RotationSpeed {get; private set;}
    //[SerializeField] float distanceTilTargetReached = 0.25f;

    public delegate void OnNodeEntered();
    public event OnNodeEntered NodeEnteredHandler;

    void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.SetNode(this);
        }
        NodeEnteredHandler?.Invoke();
    }

    #if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.8f);
        if(NextNode != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, NextNode.transform.position);
        }
    }
    #endif
}
