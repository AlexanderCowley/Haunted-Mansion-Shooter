using UnityEngine;
using UnityEngine.SceneManagement;
public class Rails : MonoBehaviour
{
    public static Player player;
    //Target Node
    //Current Node
    [SerializeField] Node[] Nodes;
    Node StartingNode;
    public static Canvas GameOverCanvas;

    void Awake() 
    {
        //Node init
        player = FindAnyObjectByType<Player>();
        StartingNode = Nodes[0];
        player.transform.position = StartingNode.transform.position;
        player.SetNode(StartingNode);

        GameOverCanvas = transform.GetChild(0).GetComponent<Canvas>();
    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickQuit()
    {
        SceneManager.LoadScene(1);
    }
    
    //For unity editor stuff
    #if UNITY_EDITOR
    void OnDrawGizmos() 
    {
        //
    }
    #endif
}
