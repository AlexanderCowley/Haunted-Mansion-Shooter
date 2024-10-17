using UnityEngine;
public class Rails : MonoBehaviour
{
    public static Player player;
    //Target Node
    //Current Node
    [SerializeField] Node[] Nodes;
    Node StartingNode;

    void Awake() 
    {
        player = FindAnyObjectByType<Player>();
        StartingNode = Nodes[0];
        player.transform.position = StartingNode.transform.position;
        player.SetNode(StartingNode);
    }
    
    //For unity editor stuff
    #if UNITY_EDITOR
    void OnDrawGizmos() 
    {
        //
    }
    #endif
}
