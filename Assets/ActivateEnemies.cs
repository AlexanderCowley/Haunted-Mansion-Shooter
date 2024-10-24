using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    Node _node;
    [SerializeField] Enemy[] Enemies;
    void Awake() 
    {
        _node = GetComponent<Node>();
        _node.NodeEnteredHandler += ActivateEnemy;
    }

    void ActivateEnemy()
    {
        for(int i = 0; i<Enemies.Length; i++)
        {
            Enemies[i].gameObject.SetActive(true);
        }
    }
}
