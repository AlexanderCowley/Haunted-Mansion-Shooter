using UnityEngine;
public class Rails : MonoBehaviour
{
    [SerializeField] Player _Player;
    //Target Node
    //Current Node
    [SerializeField] Node[] Nodes;
    Node StartingNode;

    void Awake() 
    {
        StartingNode = Nodes[0];
        _Player.transform.position = StartingNode.transform.position;
        _Player.SetNode(StartingNode);
    }
    
}
