using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyNode TargetNode;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;

    void Awake() 
    {
        if(TargetNode == null) return;
        transform.position = TargetNode.transform.position;
        SetNode(TargetNode);
    }
    //Passing in node entered
    public void SetNode(EnemyNode CurrentNode)
    {
        if(CurrentNode == null) return;
        MoveSpeed = CurrentNode.MoveSpeed;
        RotationSpeed = CurrentNode.RotationSpeed;
        TargetNode = CurrentNode.NextNode;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            TargetNode.transform.position, MoveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            TargetNode.transform.rotation, RotationSpeed * Time.deltaTime);
    }

    void Update() 
    {
        if(TargetNode == null) return;
        Move();
        Rotate();
    }
}
