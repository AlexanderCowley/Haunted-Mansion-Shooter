using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Node TargetNode;
    [SerializeField] bool InputEnabled;
    [SerializeField] float MoveSpeed;

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            TargetNode.transform.position, MoveSpeed * Time.deltaTime);
    }

    //Passing in node entered
    public void SetNode(Node CurrentNode)
    {
        MoveSpeed = CurrentNode.MoveSpeed;
        TargetNode = CurrentNode.NextNode;
    }

    void Update() 
    {
        if(TargetNode == null)
        {
            Debug.LogError("No Target Node assigned to player!");
            return;
        }
        Move();
    }
}
