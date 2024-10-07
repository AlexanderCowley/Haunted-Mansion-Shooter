using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    [field:SerializeField] public Node NextNode{get; private set;}
    [SerializeField] bool ActiveInput = true;

    [field:SerializeField] public float MoveSpeed {get; private set;}
    [field:SerializeField] public float RotationSpeed {get; private set;}
    //[SerializeField] float distanceTilTargetReached = 0.25f;

    void OnNodeEntered()
    {
        if(!ActiveInput)
        {
            //Deactivate input
        }
        else{/*activate input*/}
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.SetNode(this);
        }
        OnNodeEntered();
    }
}
