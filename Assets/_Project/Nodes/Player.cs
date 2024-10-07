using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Node TargetNode;
    public bool InputEnabled = true;
    [SerializeField] float MoveSpeed;
    [SerializeField] float RotationSpeed;

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

    //Passing in node entered
    public void SetNode(Node CurrentNode)
    {
        if(CurrentNode == null) return;
        MoveSpeed = CurrentNode.MoveSpeed;
        RotationSpeed = CurrentNode.RotationSpeed;
        TargetNode = CurrentNode.NextNode;
    }

    void Update() 
    {
        if(TargetNode == null) return;
        Move();
        Rotate();
    }
}
